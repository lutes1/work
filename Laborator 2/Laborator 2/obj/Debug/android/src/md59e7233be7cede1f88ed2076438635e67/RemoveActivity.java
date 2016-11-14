package md59e7233be7cede1f88ed2076438635e67;


public class RemoveActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Laborator_2.Activitati.RemoveActivity, Laborator 2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", RemoveActivity.class, __md_methods);
	}


	public RemoveActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == RemoveActivity.class)
			mono.android.TypeManager.Activate ("Laborator_2.Activitati.RemoveActivity, Laborator 2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
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
