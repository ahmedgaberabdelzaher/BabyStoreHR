package crc64604113006a3121f0;


public class SvgPictureDrawable
	extends android.graphics.drawable.Drawable
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_isAutoMirrored:()Z:GetIsAutoMirroredHandler\n" +
			"n_setAutoMirrored:(Z)V:GetSetAutoMirrored_ZHandler\n" +
			"n_draw:(Landroid/graphics/Canvas;)V:GetDraw_Landroid_graphics_Canvas_Handler\n" +
			"n_setBounds:(IIII)V:GetSetBounds_IIIIHandler\n" +
			"n_onBoundsChange:(Landroid/graphics/Rect;)V:GetOnBoundsChange_Landroid_graphics_Rect_Handler\n" +
			"n_isStateful:()Z:GetIsStatefulHandler\n" +
			"n_getOpacity:()I:GetGetOpacityHandler\n" +
			"n_getIntrinsicWidth:()I:GetGetIntrinsicWidthHandler\n" +
			"n_getIntrinsicHeight:()I:GetGetIntrinsicHeightHandler\n" +
			"n_setColorFilter:(Landroid/graphics/ColorFilter;)V:GetSetColorFilter_Landroid_graphics_ColorFilter_Handler\n" +
			"n_setAlpha:(I)V:GetSetAlpha_IHandler\n" +
			"n_onStateChange:([I)Z:GetOnStateChange_arrayIHandler\n" +
			"";
		mono.android.Runtime.register ("XamSvg.SvgPictureDrawable, XamSvg.Droid", SvgPictureDrawable.class, __md_methods);
	}


	public SvgPictureDrawable ()
	{
		super ();
		if (getClass () == SvgPictureDrawable.class) {
			mono.android.TypeManager.Activate ("XamSvg.SvgPictureDrawable, XamSvg.Droid", "", this, new java.lang.Object[] {  });
		}
	}

	public SvgPictureDrawable (android.graphics.Picture p0, android.graphics.RectF p1, android.graphics.Picture p2)
	{
		super ();
		if (getClass () == SvgPictureDrawable.class) {
			mono.android.TypeManager.Activate ("XamSvg.SvgPictureDrawable, XamSvg.Droid", "Android.Graphics.Picture, Mono.Android:Android.Graphics.RectF, Mono.Android:Android.Graphics.Picture, Mono.Android", this, new java.lang.Object[] { p0, p1, p2 });
		}
	}


	public boolean isAutoMirrored ()
	{
		return n_isAutoMirrored ();
	}

	private native boolean n_isAutoMirrored ();


	public void setAutoMirrored (boolean p0)
	{
		n_setAutoMirrored (p0);
	}

	private native void n_setAutoMirrored (boolean p0);


	public void draw (android.graphics.Canvas p0)
	{
		n_draw (p0);
	}

	private native void n_draw (android.graphics.Canvas p0);


	public void setBounds (int p0, int p1, int p2, int p3)
	{
		n_setBounds (p0, p1, p2, p3);
	}

	private native void n_setBounds (int p0, int p1, int p2, int p3);


	public void onBoundsChange (android.graphics.Rect p0)
	{
		n_onBoundsChange (p0);
	}

	private native void n_onBoundsChange (android.graphics.Rect p0);


	public boolean isStateful ()
	{
		return n_isStateful ();
	}

	private native boolean n_isStateful ();


	public int getOpacity ()
	{
		return n_getOpacity ();
	}

	private native int n_getOpacity ();


	public int getIntrinsicWidth ()
	{
		return n_getIntrinsicWidth ();
	}

	private native int n_getIntrinsicWidth ();


	public int getIntrinsicHeight ()
	{
		return n_getIntrinsicHeight ();
	}

	private native int n_getIntrinsicHeight ();


	public void setColorFilter (android.graphics.ColorFilter p0)
	{
		n_setColorFilter (p0);
	}

	private native void n_setColorFilter (android.graphics.ColorFilter p0);


	public void setAlpha (int p0)
	{
		n_setAlpha (p0);
	}

	private native void n_setAlpha (int p0);


	public boolean onStateChange (int[] p0)
	{
		return n_onStateChange (p0);
	}

	private native boolean n_onStateChange (int[] p0);

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
