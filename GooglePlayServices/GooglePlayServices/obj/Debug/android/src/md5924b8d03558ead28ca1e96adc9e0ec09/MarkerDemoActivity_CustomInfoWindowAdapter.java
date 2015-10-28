package md5924b8d03558ead28ca1e96adc9e0ec09;


public class MarkerDemoActivity_CustomInfoWindowAdapter
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.google.android.gms.maps.GoogleMap.InfoWindowAdapter
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_getInfoContents:(Lcom/google/android/gms/maps/model/Marker;)Landroid/view/View;:GetGetInfoContents_Lcom_google_android_gms_maps_model_Marker_Handler:Android.Gms.Maps.GoogleMap/IInfoWindowAdapterInvoker, Xamarin.GooglePlayServices.Maps\n" +
			"n_getInfoWindow:(Lcom/google/android/gms/maps/model/Marker;)Landroid/view/View;:GetGetInfoWindow_Lcom_google_android_gms_maps_model_Marker_Handler:Android.Gms.Maps.GoogleMap/IInfoWindowAdapterInvoker, Xamarin.GooglePlayServices.Maps\n" +
			"";
		mono.android.Runtime.register ("GooglePlayServicesTest.MarkerDemoActivity/CustomInfoWindowAdapter, GooglePlayServicesTest, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", MarkerDemoActivity_CustomInfoWindowAdapter.class, __md_methods);
	}


	public MarkerDemoActivity_CustomInfoWindowAdapter () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MarkerDemoActivity_CustomInfoWindowAdapter.class)
			mono.android.TypeManager.Activate ("GooglePlayServicesTest.MarkerDemoActivity/CustomInfoWindowAdapter, GooglePlayServicesTest, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public MarkerDemoActivity_CustomInfoWindowAdapter (md5924b8d03558ead28ca1e96adc9e0ec09.MarkerDemoActivity p0) throws java.lang.Throwable
	{
		super ();
		if (getClass () == MarkerDemoActivity_CustomInfoWindowAdapter.class)
			mono.android.TypeManager.Activate ("GooglePlayServicesTest.MarkerDemoActivity/CustomInfoWindowAdapter, GooglePlayServicesTest, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", "GooglePlayServicesTest.MarkerDemoActivity, GooglePlayServicesTest, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
	}


	public android.view.View getInfoContents (com.google.android.gms.maps.model.Marker p0)
	{
		return n_getInfoContents (p0);
	}

	private native android.view.View n_getInfoContents (com.google.android.gms.maps.model.Marker p0);


	public android.view.View getInfoWindow (com.google.android.gms.maps.model.Marker p0)
	{
		return n_getInfoWindow (p0);
	}

	private native android.view.View n_getInfoWindow (com.google.android.gms.maps.model.Marker p0);

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
