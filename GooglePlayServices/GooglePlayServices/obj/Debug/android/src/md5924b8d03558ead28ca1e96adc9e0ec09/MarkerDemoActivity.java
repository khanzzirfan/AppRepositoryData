package md5924b8d03558ead28ca1e96adc9e0ec09;


public class MarkerDemoActivity
	extends android.support.v4.app.FragmentActivity
	implements
		mono.android.IGCUserPeer,
		com.google.android.gms.maps.GoogleMap.OnMarkerClickListener,
		com.google.android.gms.maps.GoogleMap.OnInfoWindowClickListener,
		com.google.android.gms.maps.GoogleMap.OnMarkerDragListener
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onResume:()V:GetOnResumeHandler\n" +
			"n_OnClearMap:(Landroid/view/View;)V:__export__\n" +
			"n_OnResetMap:(Landroid/view/View;)V:__export__\n" +
			"n_onMarkerClick:(Lcom/google/android/gms/maps/model/Marker;)Z:GetOnMarkerClick_Lcom_google_android_gms_maps_model_Marker_Handler:Android.Gms.Maps.GoogleMap/IOnMarkerClickListenerInvoker, Xamarin.GooglePlayServices.Maps\n" +
			"n_onInfoWindowClick:(Lcom/google/android/gms/maps/model/Marker;)V:GetOnInfoWindowClick_Lcom_google_android_gms_maps_model_Marker_Handler:Android.Gms.Maps.GoogleMap/IOnInfoWindowClickListenerInvoker, Xamarin.GooglePlayServices.Maps\n" +
			"n_onMarkerDrag:(Lcom/google/android/gms/maps/model/Marker;)V:GetOnMarkerDrag_Lcom_google_android_gms_maps_model_Marker_Handler:Android.Gms.Maps.GoogleMap/IOnMarkerDragListenerInvoker, Xamarin.GooglePlayServices.Maps\n" +
			"n_onMarkerDragEnd:(Lcom/google/android/gms/maps/model/Marker;)V:GetOnMarkerDragEnd_Lcom_google_android_gms_maps_model_Marker_Handler:Android.Gms.Maps.GoogleMap/IOnMarkerDragListenerInvoker, Xamarin.GooglePlayServices.Maps\n" +
			"n_onMarkerDragStart:(Lcom/google/android/gms/maps/model/Marker;)V:GetOnMarkerDragStart_Lcom_google_android_gms_maps_model_Marker_Handler:Android.Gms.Maps.GoogleMap/IOnMarkerDragListenerInvoker, Xamarin.GooglePlayServices.Maps\n" +
			"";
		mono.android.Runtime.register ("GooglePlayServicesTest.MarkerDemoActivity, GooglePlayServicesTest, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", MarkerDemoActivity.class, __md_methods);
	}


	public MarkerDemoActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MarkerDemoActivity.class)
			mono.android.TypeManager.Activate ("GooglePlayServicesTest.MarkerDemoActivity, GooglePlayServicesTest, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void onResume ()
	{
		n_onResume ();
	}

	private native void n_onResume ();


	public void onClearMap (android.view.View p0)
	{
		n_OnClearMap (p0);
	}

	private native void n_OnClearMap (android.view.View p0);


	public void onResetMap (android.view.View p0)
	{
		n_OnResetMap (p0);
	}

	private native void n_OnResetMap (android.view.View p0);


	public boolean onMarkerClick (com.google.android.gms.maps.model.Marker p0)
	{
		return n_onMarkerClick (p0);
	}

	private native boolean n_onMarkerClick (com.google.android.gms.maps.model.Marker p0);


	public void onInfoWindowClick (com.google.android.gms.maps.model.Marker p0)
	{
		n_onInfoWindowClick (p0);
	}

	private native void n_onInfoWindowClick (com.google.android.gms.maps.model.Marker p0);


	public void onMarkerDrag (com.google.android.gms.maps.model.Marker p0)
	{
		n_onMarkerDrag (p0);
	}

	private native void n_onMarkerDrag (com.google.android.gms.maps.model.Marker p0);


	public void onMarkerDragEnd (com.google.android.gms.maps.model.Marker p0)
	{
		n_onMarkerDragEnd (p0);
	}

	private native void n_onMarkerDragEnd (com.google.android.gms.maps.model.Marker p0);


	public void onMarkerDragStart (com.google.android.gms.maps.model.Marker p0)
	{
		n_onMarkerDragStart (p0);
	}

	private native void n_onMarkerDragStart (com.google.android.gms.maps.model.Marker p0);

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
