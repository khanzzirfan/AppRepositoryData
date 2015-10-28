using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Gms.Maps;
using Android.Gms.Location;
using Android.Gms.Common;
using Android.Locations;
using Android.Gms.Maps.Model;
using System.IO;
using System.Net;
using System.Threading.Tasks;
//using Android.Support.V7.App;
//using Toolbar = Android.Support.V7.Widget.Toolbar;
using Org.Apache.Http.Impl.Conn.Tsccm;
using myloc = Android.Locations;
using System.Threading;
using RestSharp;


namespace GooglePlayServicesTest
{
	[Activity (Label = "Polygon Line")]
	public class PolygonLineActivity: Android.Support.V4.App.FragmentActivity,myloc.ILocationListener
	{
		private GoogleMap mMap;
		Location _currentLocation;
		LocationManager _locationManager;
		TextView _locationText;
		TextView _addressText;
		String _locationProvider;
		//MapFragment mapFragment;
		SupportMapFragment _supportMapFragment;
		bool IsGpsOn=false;

		double _stLukes_Lat = -36.88529;
		double _stlukes_long  = 	174.73363;
		double _heather_lat = -36.853174;
		double _heather_long = 174.777131;
		Button btnDistance;
		Button btnUpdateGps;
		EditText FromAddress;
		EditText ToAddress;
		TextView TvDuration;

		GmapObject rootObject = new GmapObject();
		string GeoStartAddress ="";
		string GeoEndAddress = "";
		LatLng _startLocation;
		LatLng _endLocation;
		string Duration;

		protected override void OnCreate (Bundle savedInstanceState) {
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.polyline_basic_demo);
			SetUpMapIfNeeded ();

			//Code here
			_addressText = FindViewById<TextView>(Resource.Id.address_text);
			_locationText = FindViewById<TextView>(Resource.Id.location_text);
			//FindViewById<TextView>(Resource.Id.get_address_button).Click +=  GetCurrentLocation;
			btnUpdateGps = FindViewById<Button> (Resource.Id.get_address_button);
			btnUpdateGps.Click+= GetCurrentLocation;

			btnDistance = FindViewById<Button> (Resource.Id.get_distance);
			btnDistance.Click += CalculateDistance;

			FromAddress = FindViewById<EditText> (Resource.Id.et_from);
			ToAddress = FindViewById<EditText> (Resource.Id.et_to);

			SetUpMapIfNeeded ();
			InitializeLocationManager();

			FromAddress.Text = "Auckland, New Zealand";
			ToAddress.Text = "Hamilton, New Zealand";
		}



		protected override void OnResume() 
		{
			base.OnResume ();

			if (IsGpsOn) {
				
			Task.Run(() =>
				{
					//mapFragment = new MapFragment();
					//mapFragment = (MapFragment)FragmentManager.FindFragmentById(Resource.Id.map);
					//mMap = mapFragment.Map;
					
					//Get to the resturant location; dummy location for now;
					_addressText.Text = "Still loading the map....";
						GetLocation (_heather_lat, _heather_long);
				});
			}

			RunLocationManagerUpdater ();
		}
		protected override void OnPause()
		{
			base.OnPause();

			if (IsGpsOn) {
				_locationManager.RemoveUpdates (this);
			}
		}

		protected override void OnStop()
		{
			mMap = null;
			//mapFragment = null;
			base.OnStop();
		}


		private void SetUpMapIfNeeded() 
		{
			// Do a null check to confirm that we have not already instantiated the map.
			if (mMap == null) {
				// Try to obtain the map from the SupportMapFragment.
				mMap = ((SupportMapFragment) SupportFragmentManager.FindFragmentById (Resource.Id.map)).Map;
				// Check if we were successful in obtaining the map.
				if (mMap != null) {
					SetUpMap ();
				}
			}
		}

		/**
     * This is where we can add markers or lines, add listeners or move the camera. In this case, we
     * just add a marker near Africa.
     * <p>
     * This should only be called once and when we are sure that {@link #mMap} is not null.
     */
		private void SetUpMap() {
			mMap.AddMarker (new MarkerOptions ().SetPosition (new LatLng (0, 0)).SetTitle ("Marker"));
		}

		void InitializeLocationManager()
		{
			_locationManager = (LocationManager)GetSystemService(LocationService);
			if (_locationManager.IsProviderEnabled (LocationManager.GpsProvider))
				IsGpsOn = true;
			else
				IsGpsOn = false;

			if (IsGpsOn) {
				//Check If GPS is available;
				Criteria criteriaForLocationService = new Criteria
				{
					Accuracy = Accuracy.Fine
				};
				IList<string> acceptableLocationProviders = _locationManager.GetProviders(criteriaForLocationService, true);

				if (acceptableLocationProviders.Any())
				{
					_locationProvider = acceptableLocationProviders.First();
				}
				else
				{
					_locationProvider = String.Empty;
				}



			} else {
				Toast.MakeText (this, "Turn on GPS ", ToastLength.Short).Show ();
			}
		}

		public void RunLocationManagerUpdater()
		{
			if (IsGpsOn) {
				_locationManager.RequestLocationUpdates (_locationProvider, 30000, 0, this);
				_currentLocation = _locationManager.GetLastKnownLocation (_locationProvider);
			} else {
				Toast.MakeText (this, "Turn on GPS ", ToastLength.Short).Show ();
			}
		}
		async void GetCurrentLocation(object sender, EventArgs eventArgs)
		{
			RunLocationManagerUpdater ();

			if (_currentLocation == null)
			{
				_addressText.Text = "Can't determine the current address.";
				return;
			}

			Geocoder geocoder = new Geocoder(this);
			IList<Address> addressList = await geocoder.GetFromLocationAsync(_currentLocation.Latitude, _currentLocation.Longitude, 10);

			Address address = addressList.FirstOrDefault();
			if (address != null)
			{
				StringBuilder deviceAddress = new StringBuilder();
				for (int i = 0; i < address.MaxAddressLineIndex; i++)
				{
					deviceAddress.Append(address.GetAddressLine(i))
						.AppendLine(",");
				}


				_addressText.Text = deviceAddress.ToString();

			}
			else
			{

				_addressText.Text = "Unable to determine the address.";
			}
		}


		#region ILocationListener implementation
		public void OnLocationChanged(Location location)
		{
			if (IsGpsOn) {
				_currentLocation = location;
				if (_currentLocation == null)
				{
					_locationText.Text = "Unable to determine your location.";
				}
				else
				{
					_locationText.Text = String.Format("{0},{1}", _currentLocation.Latitude, _currentLocation.Longitude);

					GetLocation(_currentLocation.Latitude, _currentLocation.Longitude);
				}
			}

		}

		public void OnProviderDisabled(string provider)
		{
			// throw new NotImplementedException();
		}

		public void OnProviderEnabled(string provider)
		{
			//throw new NotImplementedException();
		}

		public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
		{
			//throw new NotImplementedException();
		}


		async void GetLocation(double l1, double l2)
		{

			LatLng location = new LatLng(l1, l2);
			CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
			builder.Target(location);
			builder.Zoom(16);
			builder.Bearing(155);
			builder.Tilt(65);
			CameraPosition cameraPosition = builder.Build();
			CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);

			if (mMap != null)
			{


				this.RunOnUiThread(() =>
					{
						mMap.Clear();
						mMap.AnimateCamera(cameraUpdate);
						//map.MoveCamera(cameraUpdate);
						var title = _addressText.Text;
						MarkerOptions option = new MarkerOptions();
						option.SetPosition(location);
						option.SetTitle(title);

						option.InvokeIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueRed));
						mMap.AddMarker(option);
					});
			}

		}
		#endregion

		async void CalculateDistance(object sender, EventArgs eventArgs)
		{
			var fromAdd = FromAddress.Text;
			var toAdd = ToAddress.Text;
			if (string.IsNullOrEmpty (fromAdd) || string.IsNullOrEmpty (toAdd)) {
				Toast.MakeText (this, "Type From & To Address",	ToastLength.Short).Show ();
			} else {

				btnDistance.Text = "Finding Address...";
			
				LatLng start = new LatLng (_stLukes_Lat, _stlukes_long);
				LatLng end = new LatLng (_heather_lat, _heather_long);
				//var directions = await FindDirections (start, end, "");

					var directions = await FindDirectionsByAddress (fromAdd, toAdd, "driving");
				this.HandleDirectionPointsResult(directions.ToList(), _startLocation,_endLocation );
					btnDistance.Text = "Find Address";
				try 
				{
					Toast.MakeText (this, "Map Updated",	ToastLength.Short).Show ();
				}
				catch(Exception ex) {
					btnDistance.Text = "Find Address";
					Toast.MakeText (this, "Map Operation Failed. Try another address",	ToastLength.Short).Show ();
				}
			}
		}

		public async Task<IEnumerable<LatLng>> FindDirectionsByAddress(string start, string end, string mode)
		{
			var mc = new GMapDirection ();
			rootObject = mc.GetRouteByAddress(start, end, "driving");

			var leg = mc.GetLeg(rootObject);
			GeoStartAddress = leg!=null? leg.start_address:"";
			GeoEndAddress = leg != null ? leg.end_address : "";

			var duration = mc.GetGeoDuration(leg);
			var distance = mc.GetGeoDistance(leg);
			Duration = string.Format ("{0} Time: {1} Mins ", distance.value, duration.value);
			_startLocation = new LatLng (leg.start_location.lat, leg.start_location.lng);
			_endLocation = new LatLng (leg.end_location.lat, leg.end_location.lng);

			var pointsList = mc.GetGeoRouteDirectionsPoints (rootObject);
			return pointsList;
		}

		public async Task<IEnumerable<LatLng>> FindDirections(LatLng start, LatLng end, string mode)
		{
			var mc = new GMapDirection ();
			rootObject = mc.GetDistaceRoute(start, end, "driving");

			var leg = mc.GetLeg(rootObject);
			GeoStartAddress = leg!=null? leg.start_address:"";
			GeoEndAddress = leg != null ? leg.end_address : "";

			var duration = mc.GetGeoDuration(leg);
			var distance = mc.GetGeoDistance(leg);
			var pointsList = mc.GetGeoRouteDirectionsPoints (rootObject);
            

			return pointsList;
		}

		public void HandleDirectionPointsResult(List<LatLng> directionPoints, LatLng startLocation, LatLng endLocation)
		{
			var line = new PolylineOptions();
		    line.InvokeWidth(8);
		    line.InvokeColor(global::Android.Graphics.Color.Blue);

		    foreach (var point in directionPoints)
		    {
		        line.Add(point);
		    }

		    if (mMap != null)
		    {

				CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
				builder.Target(startLocation);
				builder.Zoom(10);

				builder.Bearing(0);
				builder.Tilt(0);
				CameraPosition cameraPosition = builder.Build();
				CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);

                this.RunOnUiThread(() =>
                {
						mMap.Clear();

						// Uses a colored icon.
						 mMap.AddMarker(new MarkerOptions()
							.SetPosition(startLocation)
							.SetTitle(GeoStartAddress)
							.SetSnippet("Population: Unknown")
							.InvokeIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueRed)));

						mMap.AddMarker(new MarkerOptions()
							.SetPosition(endLocation)
							.SetTitle(GeoEndAddress)
							.SetSnippet("Population: Unknown")
							.InvokeIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueRed)));
					
						mMap.AnimateCamera(cameraUpdate);

						var drawline = mMap.AddPolyline(line);    
                });
		        
		    }

		   // return 1;
		}


		private int CalculateZoomLevel(int screenWidth)
		{
			double equatorLength = 40075004; // in meters
			double widthInPixels = screenWidth;
			double metersPerPixel = equatorLength / 256;
			int zoomLevel = 1;
			while ((metersPerPixel * widthInPixels) > 2000) {
				metersPerPixel /= 2;
				++zoomLevel;
			}
			return zoomLevel;
		}
		public int GetScreenWidth()
		{
			var metrics = Resources.DisplayMetrics;
			var widthInDp = ConvertPixelsToDp(metrics.WidthPixels);
			var heightInDp = ConvertPixelsToDp(metrics.HeightPixels);

			return widthInDp;
		}

		private int ConvertPixelsToDp(float pixelValue)
		{
			var dp = (int) ((pixelValue)/Resources.DisplayMetrics.Density);
			return dp;
		}

	}

	//Get Google Map Direction
	public class GMapDirection 
	{

		public const string MODE_DRIVING = "driving";
		public const string MODE_WALKING = "walking";

		public GMapDirection()
		{
		}

		public string GetGeoMapUrl(double startLat, double startLong, double endlat, double endLong)
		{
			String url = string.Format ("http://maps.googleapis.com/maps/api/directions/json?"
			             + "origin={0},{1}&destination={2},{3}&sensor=false&units=metric&mode=driving", startLat, startLong, endlat, endLong);

            string url1 = string.Format("api/directions/json?origin={0},{1}&destination={2},{3}&sensor=false&units=metric&mode=driving", startLat, startLong, endlat, endLong);
            return url1;
		}

		public GmapObject GetRouteByAddress(string fromAddress, string toAddress, string mode)
		{
			var rootobject = new GmapObject();
			var baseAddress = "http://maps.googleapis.com/maps/";
			string url = string.Format("api/directions/json?origin={0}&destination={1}&sensor=false&units=metric&mode=driving", fromAddress,toAddress);
			var Url = url;
			var client = new RestClient(baseAddress);
			var request = new RestRequest(Url);
			var response = client.Execute(request);
			try
			{
				var responseclass = client.Execute<GmapObject>(request);
				if (responseclass.ResponseStatus == ResponseStatus.Completed)
				{
					var result = responseclass.Data;
					rootobject =result;
				}
			}
			catch (Exception ex)
			{
				var errorMsg = ex.Message;
			}
			return rootobject;
		}

        public GmapObject GetDistaceRoute(LatLng start, LatLng end, string mode)
        {
            var rootobject = new GmapObject();
            var baseAddress = "http://maps.googleapis.com/maps/";
            var Url = this.GetGeoMapUrl(start.Latitude, start.Longitude, end.Latitude, end.Longitude);

            var client = new RestClient(baseAddress);
            var request = new RestRequest(Url);
            var response = client.Execute(request);
            try
            {
                var responseclass = client.Execute<GmapObject>(request);
                if (responseclass.ResponseStatus == ResponseStatus.Completed)
                {
                    var result = responseclass.Data;
                    rootobject =result;
                }
            }
            catch (Exception ex)
            {
                var errorMsg = ex.Message;
            }
            return rootobject;
        }

	    public string GetDocument(LatLng start, LatLng end, string mode)
        {
            var baseAddress = "http://maps.googleapis.com/maps/";
            var Url = this.GetGeoMapUrl(start.Latitude, start.Longitude, end.Latitude, end.Longitude);

            var client = new RestClient(baseAddress);
            var request = new RestRequest(Url);

            var response = client.Execute(request);

            try
            {
                var responseclass = client.Execute<GmapObject>(request);
                if (responseclass.ResponseStatus == ResponseStatus.Completed)
                {
                    var result = responseclass;


                }

            }
            catch (Exception ex)
            {
                var errorMsg = ex.Message;

            }
            return null;
        }

	    public Leg GetLeg(GmapObject root)
	    {
	        if (root != null)
	        {
	            var legs = root.routes.FirstOrDefault() != null ? root.routes.FirstOrDefault().legs : null;
	            if (legs != null)
	            {
	                return legs.FirstOrDefault();
	            }
	        }
	        return null;
	    }

        public Duration GetGeoDuration(Leg root)
	    {
	        if (root != null)
	        {
	            return root.duration;
	        }
	        return null;
	    }

        public Distance GetGeoDistance(Leg root)
	    {
	        if (root != null)
	        {
	            return root.distance;
	        }
	        return null;
	    }


		public IEnumerable<LatLng> GetGeoRouteDirectionsPoints(GmapObject root)
		{
			var stepslist = new List<Step> ();
			var geoPointList = new List<LatLng> ();

			var leglist = GetLeg (root); //Get LegSteps from the route
			stepslist = leglist.steps; //Get Steps from the leg;

			if (stepslist != null && stepslist.Count > 0) {
				//Check actually there are steps

				//iterate through steps and collect route points
				foreach (var step in stepslist) {
				
					var startlocationNode = step.start_location;
					//Add Start points
					geoPointList.Add (new LatLng(startlocationNode.lat,startlocationNode.lng));

					var polylinePoints = step.polyline.points;
					var coordinateEntity = GooglePoints.Decode (polylinePoints);
					foreach (var val in coordinateEntity) {
						geoPointList.Add (new LatLng (val.Latitude, val.Longitude));
					}

					var endLocationNode = step.end_location;
					//Add End points
					geoPointList.Add (new LatLng(endLocationNode.lat,endLocationNode.lng));
				}
			}

			return geoPointList;
		}


	}



}

