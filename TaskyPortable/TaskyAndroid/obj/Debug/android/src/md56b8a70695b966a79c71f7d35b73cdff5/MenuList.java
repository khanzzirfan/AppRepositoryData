package md56b8a70695b966a79c71f7d35b73cdff5;


public class MenuList
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onResume:()V:GetOnResumeHandler\n" +
			"";
		mono.android.Runtime.register ("TaskyAndroid.Screens.MenuList, TaskyAndroid, Version=1.0.5729.30357, Culture=neutral, PublicKeyToken=null", MenuList.class, __md_methods);
	}


	public MenuList () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MenuList.class)
			mono.android.TypeManager.Activate ("TaskyAndroid.Screens.MenuList, TaskyAndroid, Version=1.0.5729.30357, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
