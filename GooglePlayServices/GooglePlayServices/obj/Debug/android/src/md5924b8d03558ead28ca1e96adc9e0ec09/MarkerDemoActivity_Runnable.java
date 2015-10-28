package md5924b8d03558ead28ca1e96adc9e0ec09;


public class MarkerDemoActivity_Runnable
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		java.lang.Runnable
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_run:()V:GetRunHandler:Java.Lang.IRunnableInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("GooglePlayServicesTest.MarkerDemoActivity/Runnable, GooglePlayServicesTest, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", MarkerDemoActivity_Runnable.class, __md_methods);
	}


	public MarkerDemoActivity_Runnable () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MarkerDemoActivity_Runnable.class)
			mono.android.TypeManager.Activate ("GooglePlayServicesTest.MarkerDemoActivity/Runnable, GooglePlayServicesTest, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void run ()
	{
		n_run ();
	}

	private native void n_run ();

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
