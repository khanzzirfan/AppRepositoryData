package md53dfaac5a461a5c0834bf5059f18713ee;


public class MenuDetailScreen
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("TaskyAndroid.Screens.MenuDetailScreen, TaskyAndroid, Version=1.0.5729.30731, Culture=neutral, PublicKeyToken=null", MenuDetailScreen.class, __md_methods);
	}


	public MenuDetailScreen () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MenuDetailScreen.class)
			mono.android.TypeManager.Activate ("TaskyAndroid.Screens.MenuDetailScreen, TaskyAndroid, Version=1.0.5729.30731, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
