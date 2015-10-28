package md5924b8d03558ead28ca1e96adc9e0ec09;


public class MarkerDemoActivity_GlobalLayoutListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.view.ViewTreeObserver.OnGlobalLayoutListener
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onGlobalLayout:()V:GetOnGlobalLayoutHandler:Android.Views.ViewTreeObserver/IOnGlobalLayoutListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("GooglePlayServicesTest.MarkerDemoActivity/GlobalLayoutListener, GooglePlayServicesTest, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", MarkerDemoActivity_GlobalLayoutListener.class, __md_methods);
	}


	public MarkerDemoActivity_GlobalLayoutListener () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MarkerDemoActivity_GlobalLayoutListener.class)
			mono.android.TypeManager.Activate ("GooglePlayServicesTest.MarkerDemoActivity/GlobalLayoutListener, GooglePlayServicesTest, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onGlobalLayout ()
	{
		n_onGlobalLayout ();
	}

	private native void n_onGlobalLayout ();

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
