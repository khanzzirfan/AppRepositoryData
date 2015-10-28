package md5924b8d03558ead28ca1e96adc9e0ec09;


public class MainActivity_DemoDetails
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("GooglePlayServicesTest.MainActivity/DemoDetails, GooglePlayServicesTest, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", MainActivity_DemoDetails.class, __md_methods);
	}


	public MainActivity_DemoDetails () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MainActivity_DemoDetails.class)
			mono.android.TypeManager.Activate ("GooglePlayServicesTest.MainActivity/DemoDetails, GooglePlayServicesTest, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

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
