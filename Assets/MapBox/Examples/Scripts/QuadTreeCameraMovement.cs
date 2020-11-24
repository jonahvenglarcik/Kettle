namespace Mapbox.Examples
{
	using Mapbox.Unity.Map;
	using Mapbox.Unity.Utilities;
	using Mapbox.Utils;
	using UnityEngine;
	using UnityEngine.EventSystems;
	using System;
	using Kettle.ClientAPITest;
	using Newtonsoft.Json;
    using System.Globalization;
    using System.Reflection;
    using System.Collections.Generic;
	using Mapbox.Unity.Location;

	public class QuadTreeCameraMovement : MonoBehaviour
	{
		[SerializeField]
		[Range(1, 20)]
		public float _panSpeed = 1.0f;

		[SerializeField]
		float _zoomSpeed = 0.25f;

		[SerializeField]
		public Camera _referenceCamera;

		[SerializeField]
		AbstractMap _mapManager;

		[SerializeField]
		bool _useDegreeMethod;

		private Vector3 _origin;
		private Vector3 _mousePosition;
		private Vector3 _mousePositionPrevious;
		private bool _shouldDrag;
		private bool _isInitialized = false;
		private Plane _groundPlane = new Plane(Vector3.up, 0);
		private bool _dragStartedOnUI = false;
		private bool setUp;

		public PinCanvasActions _PinCanvasActions;
		public NewPinMethods _NewPinMethods;

		void Awake()
		{
			if (null == _referenceCamera)
			{
				_referenceCamera = GetComponent<Camera>();
				if (null == _referenceCamera) { Debug.LogErrorFormat("{0}: reference camera not set", this.GetType().Name); }
			}
			_mapManager.OnInitialized += () =>
			{
				_isInitialized = true;
			};
		}

		private void RetrieveCurrentPins()
		{
			setUp = true;
			StartCoroutine(ClientAPITest.Get("https://kettlex-server.herokuapp.com/getPostsAroundMe",
				(string result) => {
					List<PostResponse> pr = JsonConvert.DeserializeObject<List<PostResponse>>(result);
					Debug.Log(pr.ToString());
					for (int i = 0; i < pr.Count; i++)
					{
						String RealName = pr[i].Author.RealName;
						String UserName = pr[i].Author.UserName;
						float UserLatitude = pr[i].Author.Location.Latitude;
						float UserLongitude = pr[i].Author.Location.Longitude;
						String Title = pr[i].Title;
						String Text = pr[i].Text;
						DateTime TimeStamp = pr[i].TimeStamp;
						int ApprovalRating = pr[i].ApprovalRating;
						float PostLatitude = pr[i].NodeLocation.Latitude;
						float PostLongitude = pr[i].NodeLocation.Longitude;
						//Debug.Log("Post: " + i + "(" + PostLatitude+","+PostLongitude+")");
						SetUpPins(PostLatitude, PostLongitude, Title, Text);
					}
				}));
		}

		private void SetUpPins(float Latitude, float Longitude, String Title, String Text)
		{
			Vector2d pos1 = new Vector2d(Latitude,Longitude);
			Vector3 pinPos = _mapManager.GeoToWorldPosition(pos1);
			pinPos = new Vector3(pinPos.x,0.1f,pinPos.z);
			GameObject newPin = Instantiate(pin, pinPos, Quaternion.identity);
			PinPost pPost = newPin.GetComponent<PinPost>();
			pPost.SetMessage(Title,Text,pos1);
			_PinCanvasActions.UpdatePin(pPost);
		}
		public void Update()
		{
			if (Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject())
			{
				_dragStartedOnUI = true;
			}

			if (Input.GetMouseButtonUp(0))
			{
				_dragStartedOnUI = false;
			}
		}


		private void LateUpdate()
		{
			if (!_isInitialized) { return; }

			if (!_dragStartedOnUI)
			{
				if (Input.touchSupported && Input.touchCount > 0)
				{
					HandleTouch();
				}
				else
				{
					HandleMouseAndKeyBoard();
				}
			}
			if(!setUp)
				RetrieveCurrentPins();
		}

		void HandleMouseAndKeyBoard()
		{
			// zoom
			float scrollDelta = 0.0f;
			scrollDelta = Input.GetAxis("Mouse ScrollWheel");
			ZoomMapUsingTouchOrMouse(scrollDelta);


			//pan keyboard
			float xMove = Input.GetAxis("Horizontal");
			float zMove = Input.GetAxis("Vertical");

			//PanMapUsingKeyBoard(xMove, zMove);

			//pan mouse
			PanMapUsingTouchOrMouse();
		}
		
		void HandleTouch()
		{
			float zoomFactor = 0.0f;
			//pinch to zoom.
			switch (Input.touchCount)
			{
				case 1:
					{
						PanMapUsingTouchOrMouse();
					}
					break;
				case 2:
					{
						// Store both touches.
						Touch touchZero = Input.GetTouch(0);
						Touch touchOne = Input.GetTouch(1);

						// Find the position in the previous frame of each touch.
						Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
						Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

						// Find the magnitude of the vector (the distance) between the touches in each frame.
						float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
						float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

						// Find the difference in the distances between each frame.
						zoomFactor = 0.01f * (touchDeltaMag - prevTouchDeltaMag);
					}
					ZoomMapUsingTouchOrMouse(zoomFactor);
					break;
				default:
					break;
			}
		}

		void ZoomMapUsingTouchOrMouse(float zoomFactor)
		{
			var zoom = Mathf.Max(0.0f, Mathf.Min(_mapManager.Zoom + zoomFactor * _zoomSpeed, 21.0f));
			if (Math.Abs(zoom - _mapManager.Zoom) > 0.0f)
			{
				_mapManager.UpdateMap(_mapManager.CenterLatitudeLongitude, zoom);
			}
		}

		void PanMapUsingKeyBoard(float xMove, float zMove)
		{
			if (Math.Abs(xMove) > 0.0f || Math.Abs(zMove) > 0.0f)
			{
				// Get the number of degrees in a tile at the current zoom level.
				// Divide it by the tile width in pixels ( 256 in our case)
				// to get degrees represented by each pixel.
				// Keyboard offset is in pixels, therefore multiply the factor with the offset to move the center.
				float factor = _panSpeed * (Conversions.GetTileScaleInDegrees((float)_mapManager.CenterLatitudeLongitude.x, _mapManager.AbsoluteZoom));

				var latitudeLongitude = new Vector2d(_mapManager.CenterLatitudeLongitude.x + zMove * factor * 2.0f, _mapManager.CenterLatitudeLongitude.y + xMove * factor * 4.0f);

				_mapManager.UpdateMap(latitudeLongitude, _mapManager.Zoom);
			}
		}

		void PanMapUsingTouchOrMouse()
		{
			if (_useDegreeMethod)
			{
				UseDegreeConversion();
			}
			else
			{
				UseMeterConversion();
			}
		}

		/*
		 *
		 *
		 *
		 *
		 *
		 * WORKING ON THIS PART XDDDDDDDDD
		 *
		 *
		 *
		 *
		 * 
		 */

		public void CreatePin(String[] pinInfo, Vector3 pos, Vector2d latlongDelta)
		{
			GameObject newPin = Instantiate(pin, pos, Quaternion.identity);
			PinPost pPost = newPin.GetComponent<PinPost>();
			pPost.SetMessage(pinInfo[0],pinInfo[1],latlongDelta);
			_PinCanvasActions.UpdatePin(pPost);

			LocationResponse location = new LocationResponse();
            location.Latitude = (float) latlongDelta.x;
            location.Longitude = (float) latlongDelta.y;

			//Location loc = new Location((float)latlongDelta.x, (float)latlongDelta.y);
			Location loc = new Location();
			int indexLat = ChunkManager.GetChunkNumNS(loc);
			Debug.Log("Chunk index for lat " + indexLat);
			int indexLon = ChunkManager.GetChunkNumEW(loc);
			Debug.Log("Chunk index for lat " + indexLon);

			UserResponse author = new UserResponse()
            {
                RealName = "ram",
                UserName = "rrr1",
                Location = location
            };

			PostResponse post = new PostResponse()
			{
				Author = author,
				Title = pinInfo[0],
				Text = pinInfo[1],
				TimeStamp = DateTime.Now,
				ApprovalRating = 0,
				NodeLocation = location,
				ChunkIndexNS = indexLat,
				ChunkIndexEW = indexLon
			};
			
			string jsonData = JsonConvert.SerializeObject(post);
			StartCoroutine(ClientAPITest.Post("https://kettlex-server.herokuapp.com/postMessage", jsonData));

		}
		
		public GameObject pin;
		void UseMeterConversion()
		{
			if (Input.GetMouseButtonUp(1))
			{
				var mousePosScreen = Input.mousePosition;
				mousePosScreen.z = _referenceCamera.transform.localPosition.y * 2f + _referenceCamera.transform.localPosition.y / 2;
				var pos = _referenceCamera.ScreenToWorldPoint(mousePosScreen);
				pos = new Vector3(pos.x,0.1f, pos.z);
				//Debug.Log(pos);
				//Debug.Log(_mapManager.WorldToGeoPosition(pos));
				//Debug.Log("--" + _mapManager.GeoToWorldPosition(_mapManager.WorldToGeoPosition(pos)));
				_NewPinMethods.CreateNewPin(pos,_mapManager.WorldToGeoPosition(pos));
				//Debug.Log("Latitude: " + latlongDelta.x + " Longitude: " + latlongDelta.y);
			}

			if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
			{
				var mousePosScreen = Input.mousePosition;
				//assign distance of camera to ground plane to z, otherwise ScreenToWorldPoint() will always return the position of the camera
				//http://answers.unity3d.com/answers/599100/view.html
				mousePosScreen.z = _referenceCamera.transform.localPosition.y;
				_mousePosition = _referenceCamera.ScreenToWorldPoint(mousePosScreen);

				if (_shouldDrag == false)
				{
					_shouldDrag = true;
					_origin = _referenceCamera.ScreenToWorldPoint(mousePosScreen);
				}
			}
			else
			{
				_shouldDrag = false;
			}
		}

		void UseDegreeConversion()
		{
			if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
			{
				var mousePosScreen = Input.mousePosition;
				//assign distance of camera to ground plane to z, otherwise ScreenToWorldPoint() will always return the position of the camera
				//http://answers.unity3d.com/answers/599100/view.html
				mousePosScreen.z = _referenceCamera.transform.localPosition.y;
				_mousePosition = _referenceCamera.ScreenToWorldPoint(mousePosScreen);

				if (_shouldDrag == false)
				{
					_shouldDrag = true;
					_origin = _referenceCamera.ScreenToWorldPoint(mousePosScreen);
				}
			}
			else
			{
				_shouldDrag = false;
			}

			if (_shouldDrag == true)
			{
				var changeFromPreviousPosition = _mousePositionPrevious - _mousePosition;
				if (Mathf.Abs(changeFromPreviousPosition.x) > 0.0f || Mathf.Abs(changeFromPreviousPosition.y) > 0.0f)
				{
					_mousePositionPrevious = _mousePosition;
					var offset = _origin - _mousePosition;

					if (Mathf.Abs(offset.x) > 0.0f || Mathf.Abs(offset.z) > 0.0f)
					{
						if (null != _mapManager)
						{
							// Get the number of degrees in a tile at the current zoom level.
							// Divide it by the tile width in pixels ( 256 in our case)
							// to get degrees represented by each pixel.
							// Mouse offset is in pixels, therefore multiply the factor with the offset to move the center.
							float factor = _panSpeed * Conversions.GetTileScaleInDegrees((float)_mapManager.CenterLatitudeLongitude.x, _mapManager.AbsoluteZoom) / _mapManager.UnityTileSize;

							var latitudeLongitude = new Vector2d(_mapManager.CenterLatitudeLongitude.x + offset.z * factor, _mapManager.CenterLatitudeLongitude.y + offset.x * factor);
							_mapManager.UpdateMap(latitudeLongitude, _mapManager.Zoom);
						}
					}
					_origin = _mousePosition;
				}
				else
				{
					if (EventSystem.current.IsPointerOverGameObject())
					{
						return;
					}
					_mousePositionPrevious = _mousePosition;
					_origin = _mousePosition;
				}
			}
		}

		private Vector3 getGroundPlaneHitPoint(Ray ray)
		{
			float distance;
			if (!_groundPlane.Raycast(ray, out distance)) { return Vector3.zero; }
			return ray.GetPoint(distance);
		}
	}
}