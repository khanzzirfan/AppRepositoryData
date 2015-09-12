package md5497cc9eaf84fbb43cf37872ebfd60cba;


public class FruitList
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
		mono.android.Runtime.register ("TaskyAndroid.Screens.FruitList, TaskyAndroid, Version=1.0.5729.33332, Culture=neutral, PublicKeyToken=null", FruitList.class, __md_methods);
	}


	public FruitList () throws java.lang.Throwable
	{
		super ();
		if (getClass () == FruitList.class)
			mono.android.TypeManager.Activate ("TaskyAndroid.Screens.FruitList, TaskyAndroid, Version=1.0.5729.33332, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
