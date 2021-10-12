using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.Win32
{
    /// <summary>
    /// User32.dll
    /// </summary>
    public static partial class UnsafeNativeMethods
    {
        #region Window Functions                                    窗口函数

        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数创建一个重叠式窗口、弹出式窗口或子窗口。</para>
        /// <para>它指定窗口类，窗口标题，窗口风格，以及窗口的初始位置及大小（可选的）。</para>
        /// <para>函数也指该窗口的父窗口或所属窗口（如果存在的话），及窗口的菜单。</para>
        /// <para>若要使用除CreateWindow函数支持的风格外的扩展风格，则使用CreateWindowEx函数代替CreateWindow函数。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>在返回前，CreateWindow给窗口过程发送一个WM_CREATE消息。</para>
        /// <para>对于层叠，弹出式和子窗口，CreateWindow给窗口发送WM_CREATE，WM_GETMINMAXINFO和WM_NCCREATE消息。</para>
        /// <para>消息WM_CREATE的IParam参数包含一个指向CREATESTRUCT结构的指针。</para>
        /// <para>如果指定了WS_VISIBLE风格，CreateWindow向窗口发送所有需要激活和显示窗口的消息。</para>
        /// </summary>
        /// <param name="lpClassName">指向一个空结束的字符串或整型数atom。如果该参数是一个整型量，它是由此前调用theGlobalAddAtom函数产生的全局量。这个小于0xC000的16位数必须是lpClassName参数字的低16位，该参数的高位必须是0。如果lpClassName是一个字符串，它指定了窗口的类名。这个类名可以是任何用函数RegisterClass注册的类名，或是任何预定义的控制类名。请看说明部分的列表。</param>
        /// <param name="lpWindowName">指向一个指定窗口名的空结束的字符串指针。如果窗口风格指定了标题条，由lpWindowName指向的窗口标题将显示在标题条上。当使用Createwindow函数来创建控制例如按钮，选择框和静态控制时，可使用lpWindowName来指定控制文本。</param>
        /// <param name="dwStyle">指定创建窗口的风格。该参数可以是下列窗口风格的组合再加上说明部分的控制风格。风格意义：WS</param>
        /// <param name="x">指定窗口的初始水平位置。对一个层叠或弹出式窗口，X参数是屏幕坐标系的窗口的左上角的初始X坐标。对于子窗口，x是子窗口左上角相对父窗口客户区左上角的初始X坐标。如果该参数被设为CW_USEDEFAULT则系统为窗口选择缺省的左上角坐标并忽略Y参数。CW_USEDEFAULT只对层叠窗口有效，如果为弹出式窗口或子窗口设定，则X和y参数被设为零。</param>
        /// <param name="y">指定窗口的初始垂直位置。对一个层叠或弹出式窗口，y参数是屏幕坐标系的窗口的左上角的初始y坐标。对于子窗口，y是子窗口左上角相对父窗口客户区左上角的初始y坐标。对于列表框，y是列表框客户区左上角相对父窗口客户区左上角的初始y坐标。如果层叠窗口是使用WS_VISIBLE风格位创建的并且X参数被设为CW_USEDEFAULT，则系统将忽略y参数。</param>
        /// <param name="nWidth">以设备单元指明窗口的宽度。对于层叠窗口，nWidth或是屏幕坐标的窗口宽度或是CW_USEDEFAULT。若nWidth是CW_USEDEFAULT，则系统为窗口选择一个缺省的高度和宽度：缺省宽度为从初始X坐标开始到屏幕的右边界，缺省高度为从初始Y坐标开始到目标区域的顶部。CW_USEDEFAULT只对层叠窗口有效；如果为弹出式窗口和子窗口设定CW_USEDEFAULT标志则nWidth和nHeight被设为零。</param>
        /// <param name="nHeight">以设备单元指明窗口的高度。对于层叠窗口，nHeight是屏幕坐标的窗口宽度。若nWidth被设为CW_USEDEFAULT，则系统忽略nHeight参数。</param>
        /// <param name="hWndParent">指向被创建窗口的父窗口或所有者窗口的句柄。若要创建一个子窗口或一个被属窗口，需提供一个有效的窗口句柄。这个参数对弹出式窗口是可选的。Windows NT 5.0；创建一个消息窗口，可以提供HWND_MESSAGE或提供一个己存在的消息窗口的句柄。</param>
        /// <param name="hMenu">菜单句柄，或依据窗口风格指明一个子窗口标识。对于层叠或弹出式窗口，hMenu指定窗口使用的菜单：如果使用了菜单类，则hMenu可以为NULL。对于子窗口，hMenu指定了该子窗口标识（一个整型量），一个对话框使用这个整型值将事件通知父类。应用程序确定子窗口标识，这个值对于相同父窗口的所有子窗口必须是唯一的。</param>
        /// <param name="hInstance">与窗口相关联的模块实例的句柄。</param>
        /// <param name="lpParam">指向一个值的指针，该值传递给窗口WM_CREATE消息。该值通过在IParam参数中的CREATESTRUCT结构传递。如果应用程序调用CreateWindow创建一个MDI客户窗口，则lpParam必须指向一个CLIENTCREATESTRUCT结构。</param>
        /// <returns>如果函数成功，返回值为新窗口的句柄：如果函数失败，返回值为NULL。若想获得更多错误信息，请调用GetLastError函数。</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr CreateWindow(string lpClassName, string lpWindowName, int dwStyle, int x, int y, int nWidth, int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);
        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数创建一个具有扩展风格的层叠式窗口、弹出式窗口或子窗口，其他与CreateWindow函数相同。关于创建窗口和其他参数的内容，请参看CreateWindow。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>:参见CreateWindow。</para>
        /// <para>速查：Windows NT：3.1以上版本；Windows：95以上版本；Windows CE：1.0以上版本；头文件：winuser.h；库文件：USer32.lib;Unicode：在Windows NT上实现为Unicode和ANSI两种版本。</para>
        /// </summary>
        /// <param name="dwExStyle">指定窗口的扩展风格。该参数可以是下列值：WS_EX</param>
        /// <param name="lpClassName">指向一个空结束的字符串或整型数atom。如果该参数是一个整型量，它是由此前调用RegisterClass或RegisterClassEx函数返回的值。这个小于OxCOOO的16位数必须是IpClassName参数字的低16位，该参数的高位必须是O。如果lpClassName是一个字符串，它指定了窗口的类名。这个类名可以是任何用函数RegisterClassEx注册的类名，或是任何预定义的控制类名。请看说明部分的列表。</param>
        /// <param name="lpWindowName">指向一个指定窗口名的空结束的字符串指针。如果窗口风格指定了标题条，由lpWindowName指向的窗口标题将显示在标题条上。当使用CreateWindow函数来创建控制例如按钮，选择框和静态控制时，可使用lpWindowName来指定控制文本。</param>
        /// <param name="dwStyle">指定创建窗口的风格。该参数可以是下列窗口风格的组合再加上说明部分的控制风格。</param>
        /// <param name="x">指定窗口的初始水平位置。对一个层叠或弹出式窗口，X参数是屏幕坐标系的窗口的左上角的初始X坐标。对于子窗口，x是子窗口左上角相对父窗口客户区左上角的初始X坐标。如果该参数被设为CW_USEDEFAULT则系统为窗口选择缺省的左上角坐标并忽略Y参数。CW_USEDEFAULT只对层叠窗口有效，如果为弹出式窗口或子窗口设定，则X和y参数被设为零。</param>
        /// <param name="y">指定窗口的初始垂直位置。对一个层叠或弹出式窗日，y参数是屏幕坐标系的窗口的左上角的初始y坐标。对于子窗口，y是子窗口左上角相对父窗口客户区左上角的初始y坐标。对于列表框，y是列表框客户区左上角相对父窗口客户区左上角的初始y坐标。如果层叠窗口是使用WS_VISIBLE风格位创建的并且X参数被设为CW_USEDEFAULT，则系统将忽略y参数。</param>
        /// <param name="nWidth">以设备单元指明窗口的宽度。对于层叠窗口，nWidth或是屏幕坐标的窗口宽度或是CW_USEDEFAULT。若nWidth是CW_USEDEFAULT，则系统为窗口选择一个缺省的高度和宽度：缺省宽度为从初始X坐标开始到屏幕的右边界，缺省高度为从初始X坐标开始到目标区域的顶部。CW_USEDEFAULT只对层叠窗口有效；如果为弹出式窗口和子窗口设定CW_USEDEFAULT标志则nWidth和nHeight被设为零。</param>
        /// <param name="nHeight">以设备单元指明窗口的高度。对于层叠窗口，nHeight是屏幕坐标的窗口宽度。若nWidth被设为CW_USEDEFAULT，则系统忽略nHeight参数。</param>
        /// <param name="hWndParent">指向被创建窗口的父窗口或所有者窗口的句柄。若要创建一个子窗口或一个被属窗口，需提供一个有效的窗口句柄。这个参数对弹出式窗口是可选的。Windows NT 5.0；创建一个消息窗口，可以提供HWND_MESSAGE或提供一个己存在的消息窗口的句柄。</param>
        /// <param name="hMenu">菜单句柄，或依据窗口风格指明一个子窗口标识。对于层叠或弹出式窗口，hMenu指定窗口使用的菜单：如果使用了菜单类，则hMenu可以为NULL。对于子窗口，hMenu指定了该子窗口标识（一个整型量），一个对话框使用这个整型值将事件通知父类。应用程序确定子窗口标识，这个值对于相同父窗口的所有子窗口必须是唯一的。</param>
        /// <param name="hInstance">与窗口相关联的模块实例的句柄。</param>
        /// <param name="lpParam">指向一个值的指针，该值传递给窗口WM_CREATE消息。该值通过在IParam参数中的CREATESTRUCT结构传递。如果应用程序调用CreateWindow创建一个MDI客户窗口，则lpParam必须指向一个CLIENTCREATESTRUCT结构。</param>
        /// <returns>如果函数成功，返回值为新窗口的句柄：如果函数失败，返回值为NULL。若想获得更多错误信息，请调用GetLastError函数。</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr CreateWindowEx(int dwExStyle, string lpClassName, string lpWindowName, int dwStyle, int x, int y, int nWidth, int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);
        /// <summary>
        /// <para>功能:</para>
        /// <para>销毁指定的窗口。这个函数通过发送WM_DESTROY 消息和 WM_NCDESTROY 消息使窗口无效并移除其键盘焦点。这个函数还销毁窗口的菜单，清空线程的消息队列，销毁与窗口过程相关的定时器，解除窗口对剪贴板的拥有权，打断剪贴板器的查看链。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>一个线程不能使用本函数销毁别的线程创建的窗口。如果这个窗口是一个不具有WS_EX_NOPARENTNOTIFY 样式的子窗口，则销毁窗口时将发WM_PARENTNOTIFY 消息给其父窗口。</para>
        /// <para>Windows CE: 本函数将不发送 WM_NCDESTROY 消息.</para>
        /// </summary>
        /// <param name="hWnd">将被销毁的窗口的句柄。</param>
        /// <returns>如果函数成功，返回值为非零：如果函数失败，返回值为零。若想获得更多错误信息，请调用GetLastError函数。</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DestroyWindow(IntPtr hWnd);

        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数返回桌面窗口的句柄。桌面窗口覆盖整个屏幕。桌面窗口是一个要在其上绘制所有的图标和其他窗口的区域。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>无</para>
        /// </summary>
        /// <returns>函数返回桌面窗口的句柄。</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();
        /// <summary>
        /// FindWindow函数返回与指定字符创相匹配的窗口类名或窗口名的最顶层窗口的窗口句柄。这个函数不会查找子窗口。
        /// </summary>
        /// <param name="lpClassName">指向一个以null结尾的、用来指定类名的字符串或一个可以确定类名字符串的原子。如果这个参数是一个原子，那么它必须是一个在调用此函数前已经通过GlobalAddAtom函数创建好的全局原子。这个原子（一个16bit的值），必须被放置在lpClassName的低位字节中，lpClassName的高位字节置零。</param>
        /// <param name="lpWindowName">指向一个以null结尾的、用来指定窗口名（即窗口标题）的字符串。如果此参数为NULL，则匹配所有窗口名。</param>
        /// <returns>如果函数执行成功，则返回值是拥有指定窗口类名或窗口名的窗口的句柄。如果函数执行失败，则返回值为 NULL 。可以通过调用GetLastError函数获得更加详细的错误信息。</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        /// <summary>
        /// <para>功能:</para>
        /// <para>在窗口列表中寻找与指定条件相符的第一个子窗口 。</para>
        /// <para>该函数获得一个窗口的句柄，该窗口的类名和窗口名与给定的字符串相匹配。</para>
        /// <para>这个函数查找子窗口，从排在给定的子窗口后面的下一个子窗口开始。在查找时不区分大小写。</para>
        /// </summary>
        /// <param name="hwndParent">要查找的子窗口所在的父窗口的句柄（如果设置了hwndParent，则表示从这个hwndParent指向的父窗口中搜索子窗口）。如果hwndParent为 0 ，则函数以桌面窗口为父窗口，查找桌面窗口的所有子窗口。Windows NT5.0 and later：如果hwndParent是HWND_MESSAGE，函数仅查找所有消息窗口。</param>
        /// <param name="hwndChildAfter">子窗口句柄。查找从在Z序中的下一个子窗口开始。子窗口必须为hwndParent窗口的直接子窗口而非后代窗口。如果HwndChildAfter为NULL，查找从hwndParent的第一个子窗口开始。如果hwndParent 和 hwndChildAfter同时为NULL，则函数查找所有的顶层窗口及消息窗口。</param>
        /// <param name="lpszClass">指向一个指定了类名的空结束字符串，或一个标识类名字符串的成员的指针。如果该参数为一个成员，则它必须为前次调用theGlobaIAddAtom函数产生的全局成员。该成员为16位，必须位于lpClassName的低16位，高位必须为0。</param>
        /// <param name="lpszWindow">指向一个指定了窗口名（窗口标题）的空结束字符串。如果该参数为 NULL，则为所有窗口全匹配。</param>
        /// <returns>Long，找到的窗口的句柄。如未找到相符窗口，则返回零。会设置GetLastError如果函数成功，返回值为具有指定类名和窗口名的窗口句柄。如果函数失败，返回值为NULL。若想获得更多错误信息，请调用GetLastError函数。</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数获得给定窗口的可视状态。</para>
        /// <para>.</para>
        /// <para>备注：</para>
        /// <para>窗口的可视状态由WS_VISIBLE位指示。</para>
        /// <para>当设置了WS_VISIBLE位，窗口就可显示，而且只要窗口具有WS_VISIBLE风格，任何画在窗口的信息都将被显示。</para>
        /// <para>.</para>
        /// </summary>
        /// <param name="hWnd">被测试窗口的句柄。</param>
        /// <returns>如果指定的窗口及其父窗口具有WS_VISIBLE风格，返回值为非零；如果指定的窗口及其父窗口不具有WS_VISIBLE风格，返回值为零。由于返回值表明了窗口是否具有Ws_VISIBLE风格，因此，即使该窗口被其他窗口遮盖，函数返回值也为非零。</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWindowVisible(IntPtr hWnd);
        /// <summary>
        /// 该函数改变一个子窗口，弹出式窗口式顶层窗口的尺寸，位置和Z序。 
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="hWndInsertAfter">在z序中的位于被置位的窗口前的窗口句柄.可以为特殊值HWND_</param>
        /// <param name="x">以客户坐标指定窗口新位置的左边界</param>
        /// <param name="y">以客户坐标指定窗口新位置的顶边界</param>
        /// <param name="cx">以像素指定窗口的新的宽度</param>
        /// <param name="cy">以像素指定窗口的新的高度</param>
        /// <param name="uFlags">窗口尺寸和定位的标志。该参数可以是下列值的组合.可以为特殊值SWP_</param>
        /// <returns>如果函数成功，返回值为非零；如果函数失败，返回值为零。</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);

        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数返回指定窗口的边框矩形的尺寸。该尺寸以相对于屏幕坐标左上角的屏幕坐标给出。</para>
        /// </summary>
        /// <param name="hWnd">窗口句柄。</param>
        /// <param name="lpRect">指向一个RECT结构的指针，该结构接收窗口的左上角和右下角的屏幕坐标。</param>
        /// <returns>如果函数成功，返回值为非零：如果函数失败，返回值为零。若想获得更多错误信息，请调用GetLastError函数。</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, ref NativeMethods.RECT lpRect);
        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数获取窗口客户区的坐标。</para>
        /// <para>客户区坐标指定客户区的左上角和右下角。</para>
        /// <para>由于客户区坐标是相对窗口客户区的左上角而言的，因此左上角坐标为（0，0）</para>
        /// </summary>
        /// <param name="hWnd">程序窗口的句柄。</param>
        /// <param name="lpRect">指针，指向一个RECT类型的rectangle结构。该结构有四个LONG字段,分别为left、top、right和bottom。GetClientRect将这四个字段设定为窗口显示区域的尺寸。left和top字段通常设定为0。right和bottom字段设定为显示区域的宽度和高度（像素点数）。 也可以是一个CRect对象指针。CRect对象有多个参数，与RECT用法相同。函数的作用总的来说就是把客户区的大小写进第二个参数所指的Rect结构当中。</param>
        /// <returns>如果函数成功，返回一个非零值。如果函数失败，返回零。要得到更多的错误信息，请使用GetLastError函数。</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetClientRect(IntPtr hWnd, ref NativeMethods.RECT lpRect);

        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数依据所需客户矩形的大小，计算需要的窗口矩形的大小。计算出的窗口矩形随后可以传递给CreateWindow函数，用于创建一个客户区所需大小的窗口。</para>
        /// <para>要指定一个扩展窗口样式，使用AdjustWindowRectEx功能。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>客户矩形是指完全包含一个客户区域的最小矩形；窗口矩形是指完全包含一个窗口的最小矩形，该窗口包含客户区与非客户区。</para>
        /// <para>当一个菜单条下拉出两行或更多行时，AdjustWindowRect函数不增加额外的空间。</para>
        /// </summary>
        /// <param name="lpRect">指向RECT结构的指针，该结构包含所需客户区域的左上角和右下角的坐标。函数返回时，该结构容纳所需客户区域的窗口的左上角和右下角的坐标。</param>
        /// <param name="dwStyle">指定将被计算尺寸的窗口的窗口风格。</param>
        /// <param name="bMenu">指示窗口是否有菜单。</param>
        /// <returns>如果函数成功，返回值为非零；如果函数失败，返回值为零。若想获得更多的错误信息，调用GetLastError函数。</returns>
        [DllImport("user32.DLL")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AdjustWindowRect(ref NativeMethods.RECT lpRect, int dwStyle, bool bMenu);
        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数依据所需客户矩形大小，计算需要的窗口矩形的大小。计算出的窗口矩形随后可以传送给CreateWindowEx函数，用于创建一个客户区所需大小的窗口。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>客户矩形是指完全包含一个客户区域的最小矩形；窗口矩形是指完全包含一个窗口的最小矩形，该窗口包含客户区与非客户区。</para>
        /// <para>当一个菜单条下拉出两行或更多行时，AdjustWindowRectEx函数不增加额外的空间。</para>
        /// <para>该AdjustWindowRectEx功能不走WS_VSCROLL和WS_HSCROLL风格的考虑。考虑到滚动条，调用GetSystemMetrics的使用功能SM_CXVSCROLL或SM_CYHSCROLL。</para>
        /// </summary>
        /// <param name="lpRect">指向RECT结构的指针，该结构包含所需客户区域的左上角和右下角的坐标。函数返回时，该结构包含容纳所需客户区域的窗口的左上角和右下角的坐标。</param>
        /// <param name="dwStyle">指定将被计算尺寸的窗口的窗口风格。</param>
        /// <param name="bMenu">指示窗口是否有菜单。</param>
        /// <param name="dwExStyle">指定将被计算尺寸的窗口的扩展窗口风格。</param>
        /// <returns>如果函数成功，返回值为非零；如果函数失败，返回值为零。若想获得更多错误信息，请调用GetLastError函数</returns>
        [DllImport("user32.DLL")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AdjustWindowRectEx(ref NativeMethods.RECT lpRect, int dwStyle, bool bMenu, int dwExStyle);

        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数测试一个窗口是否是指定父窗口的子窗口或后代窗口。如果该父窗口是在父窗口的链表上则子窗口是指定父窗口的直接后代。父窗口链表从原始层叠窗口或弹出窗口一直连到该子窗口。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// </summary>
        /// <param name="hWndParent">父窗口句柄。</param>
        /// <param name="hWnd">将被测试的窗口句柄。</param>
        /// <returns>如果窗口是指定窗口的子窗口或后代窗口，则返回值为非零。如果窗口不是指定窗口的子窗口或后代窗口，则返回值为零。</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsChild(IntPtr hWndParent, IntPtr hWnd);
        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数获得一个指定子窗口的父窗口句柄。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>WindowsCE：Windows CE1.0版本不支持除了对话框之外的所属子窗口。</para>
        /// <para>To obtain a window&apos;s owner window, instead of using GetParent, use GetWindow with the GW_OWNER flag.</para>
        /// <para>To obtain the parent window and not the owner, instead of using GetParent, use GetAncestor with the GA_PARENT flag.</para>
        /// </summary>
        /// <param name="hWnd">子窗口句柄，函数要获得该子窗口的父窗口句柄。</param>
        /// <returns>如果函数成功，返回值为父窗口句柄。如果窗口无父窗口，则函数返回NULL。若想获得更多错误信息，请调用GetLastError函数。</returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetParent(IntPtr hWnd);
        /// <summary>
        /// Retrieves the handle to the ancestor of the specified window.
        /// </summary>
        /// <param name="hWnd">A handle to the window whose ancestor is to be retrieved. If this parameter is the desktop window, the function returns NULL.</param>
        /// <param name="gaFlags">The ancestor to be retrieved. This parameter can be one of the following values.</param>
        /// <returns>The return value is the handle to the ancestor window.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetAncestor(IntPtr hWnd, uint gaFlags);
        /// <summary>
        /// <para>功能:</para>
        /// <para>Retrieves a handle to a window that has the specified relationship (Z-Order or owner) to the specified window.</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>The EnumChildWindows function is more reliable than calling GetWindow in a loop.</para>
        /// <para>An application that calls GetWindow to perform this task risks being caught in an infinite loop or referencing a handle to a window that has been destroyed.</para>
        /// </summary>
        /// <param name="hWnd">A handle to a window. The window handle retrieved is relative to this window, based on the value of the uCmd parameter.</param>
        /// <param name="uCmd">The relationship between the specified window and the window whose handle is to be retrieved. This parameter can be one of the following values.</param>
        /// <returns>If the function succeeds, the return value is a window handle. If no window exists with the specified relationship to the specified window, the return value is NULL. To get extended error information, call GetLastError.</returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetWindow(IntPtr hWnd, uint uCmd);
        /// <summary>
        /// <para>功能:</para>
        /// <para>Changes the parent window of the specified child window.</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>An application can use the SetParent function to set the parent window of a pop-up, overlapped, or child window.</para>
        /// <para>If the window identified by the hWndChild parameter is visible, the system performs the appropriate redrawing and repainting.</para>
        /// <para>For compatibility reasons, SetParent does not modify the WS_CHILD or WS_POPUP window styles of the window whose parent is being changed. Therefore, if hWndNewParent is NULL, you should also clear the WS_CHILD bit and set the WS_POPUP style after calling SetParent. Conversely, if hWndNewParent is not NULL and the window was previously a child of the desktop, you should clear the WS_POPUP style and set the WS_CHILD style before calling SetParent.</para>
        /// <para>When you change the parent of a window, you should synchronize the UISTATE of both windows. For more information, see WM_CHANGEUISTATE and WM_UPDATEUISTATE.</para>
        /// </summary>
        /// <param name="hWndChild">A handle to the child window.</param>
        /// <param name="hWndNewParent">A handle to the new parent window. If this parameter is NULL, the desktop window becomes the new parent window. If this parameter is HWND_MESSAGE, the child window becomes a message-only window.</param>
        /// <returns>If the function succeeds, the return value is a handle to the previous parent window.If the function fails, the return value is NULL. To get extended error information, call GetLastError.</returns>
        [DllImport("User32", SetLastError = true)]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数返回指定窗口的标题文本（如果存在）的字符长度。如果指定窗口是一个控件，函数将返回控制内文本的长度。但是GetWindowTextLength函数不能返回在其他应用程序中的控制的文本长度。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>如果目标窗口属于当前进程，GetWindowTextLength函数给指定的窗口或控制发送WM_GETTEXT消息。</para>
        /// <para>在一定的条件下，函数GetWindowTextLength的返回值可能比实际的文本长度大。这是由于ANSI和Unlcode的混和使用以及系统允许DBCS字符在文本内存在的原因，但是函数返回值要至少与文本的实际长度相等，因此可以利用这一点指导缓存区的分配。在应用程序既使用ANSI函数又使用Unicode的普通对话框时就会有缓存分配的问题；同样，当应用程序在一个Unicode的窗口过程中使用了ANSI的GetWindowTextLength函数，或在一个ANSI的窗口过程中使用了Unicode的GetWindowTextLength函数的时候也有缓存分配的问题。查看ANSI和Vnicode函数，参考Wind32函数prototypes。</para>
        /// <para>要获得文本的实际长度，使用WM_GETTEXT, LB_GETTEXT或CB_GETLBTBTEXT消息或GetWindowText函数。</para>
        /// </summary>
        /// <param name="hWnd">窗口的句柄。</param>
        /// <returns>如果函数成功，返回值为文本的字符长度。在一定的条件下，返回值可能比实际的文本长度大。请参看说明。如果窗口无文本，返回值为零。若想获得更多错误信息，请调用GetLastError函数。</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowTextLength(IntPtr hWnd);
        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数将指定窗口的标题条文本（如果存在）拷贝到一个缓存区内。</para>
        /// <para>如果指定的窗口是一个控件，则拷贝控件的文本。但是，GetWindowText不能接收其他应用程序中控件的文本。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>如果目标窗口属于当前进程，GetWindowText函数给指定的窗口或控件发送WM_GETTEXT消息。</para>
        /// <para>如果目标窗口属于其他进程，并且有一个窗口标题，则GetWindowTeXt返回窗口的标题文本，如果窗口无标题，则函数返回空字符串。</para>
        /// </summary>
        /// <param name="hWnd">带文本的窗口或控件的句柄。</param>
        /// <param name="lpString">指向接收文本的缓冲区的指针。</param>
        /// <param name="nMaxCount">指定要保存在缓冲区内的字符的最大个数，其中包含NULL字符。如果文本超过界限，它就被截断。</param>
        /// <returns>如果函数成功，返回值是拷贝的字符串的字符个数，不包括中断的空字符；如果窗口无标题栏或文本，或标题栏为空，或窗口或控制的句柄无效，则返回值为零。若想获得更多错误信息，请调用GetLastError函数。函数不能返回在其他应用程序中的编辑控件的文本。</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数改变指定窗口的标题栏的文本内容（如果窗口有标题栏）。</para>
        /// <para>如果指定窗口是一个控件，则改变控件的文本内容。</para>
        /// <para>然而，SetWindowText函数不改变其他应用程序中的控件的文本内容。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>如果目标窗口属于当前进程，SetWindowText函数会使WM_SETTEXT消息发送给指定的窗口或控件。然而，如果控件是以WS_CAPTION风格创建的列表框控件，SetWindowText函数将为控件设置文本，而不是为列表项设置文本。[1]</para>
        /// <para>SetWindowText函数不扩展Tab字符（ASCII代码0×09），Tab字符以字符‘|’来显示。</para>
        /// </summary>
        /// <param name="hWnd">要改变文本内容的窗口或控件的句柄。</param>
        /// <param name="lpString">指向一个空结束的字符串的指针，该字符串将作为窗口或控件的新文本。</param>
        /// <returns>如果函数成功，返回值为非零；如果函数失败，返回值为零。若想获得更多错误信息，请调用GetLastError函数。</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowText(IntPtr hWnd, string lpString);

        /// <summary>
        /// <para>功能:该函数能在显示与隐藏窗口时能产生特殊的效果。有两种类型的动画效果：滚动动画和滑动动画。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>可以将AW_HOR_POSITIVE或AW_HOR_NEGTVE与AW_VER_POSITVE或AW_VER_NEGATIVE组合来激活一个窗口。</para>
        /// <para>.</para>
        /// <para>可能需要在该窗口的窗口过程和它的子窗口的窗口过程中处理WM_PRINT或WM_PRINTCLIENT消息。对话框，控制，及共用控制已处理WM_PRINTCLIENT消息，缺省窗口过程也已处理WM_PRINT消息。</para>
        /// </summary>
        /// <param name="hWnd">指定产生动画的窗口的句柄</param>
        /// <param name="dwTime">指明动画持续的时间（以微秒计），完成一个动画的标准时间为200微秒</param>
        /// <param name="dwFlags">指定动画类型。这个参数可以是一个或多个下列标志的组合。标志描述：</param>
        /// <summary>
        /// <para>AW_SLIDE：使用滑动类型。缺省则为滚动动画类型。当使用AW_CENTER标志时，这个标志就被忽略。</para>
        /// <para>AW_ACTIVE：激活窗口。在使用了AW_HIDE标志后不要使用这个标志。</para>
        /// <para>AW_BLEND：使用淡出效果。只有当hWnd为顶层窗口的时候才可以使用此标志。</para>
        /// <para>AW_HIDE：隐藏窗口，缺省则显示窗口。</para>
        /// <para>AW_CENTER：若使用了AW_HIDE标志，则使窗口向内重叠；若未使用AW_HIDE标志，则使窗口向外扩展。</para>
        /// <para>AW_HOR_POSITIVE：自左向右显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略。</para>
        /// <para>AW_VER_POSITIVE：自顶向下显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略。</para>
        /// <para>AW_VER_NEGATIVE：自下向上显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略。</para>
        /// </summary>
        /// <returns>如果函数成功，返回值为非零；如果函数失败，返回值为零。在下列情况下函数将失败：窗口使用了窗口边界；窗口已经可见仍要显示窗口；窗口已经隐藏仍要隐藏窗口。若想获得更多错误信息，请调用GetLastError函数。</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AnimateWindow(IntPtr hWnd, int dwTime, int dwFlags);
        /// <summary>
        /// 该函数设置指定窗口的显示状态。
        /// </summary>
        /// <param name="hWnd">指窗口句柄。</param>
        /// <param name="nCmdShow">指定窗口如何显示。</param>
        /// <returns>如果窗口之前可见，则返回值为非零。如果窗口之前被隐藏，则返回值为零。</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        /// <summary>
        /// <para>功能:</para>
        /// <para>更新一个分层的窗口的位置，大小，形状，内容和半透明度</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>无</para>
        /// <para>.</para>
        /// <para>下列参数可被设置到dwFlags:</para>
        /// <para>ULW_ALPHA：使用pblend为混合功能,如果显示模式为256色或更少，这个值和ULW_OPAQUE效果相同。</para>
        /// <para>ULW_COLORKEY：使用crKey值为颜色的透明度。</para>
        /// <para>ULW_OPAQUE：绘制一个不透明分层窗口。</para>
        /// <para>如果hdcSrc为NULL，dwFlags应为零。</para>
        /// </summary>
        /// <param name="hWnd">一个分层的窗口句柄;一个分层的窗口当用CreateWindowEx函数创建窗口时指定WS_EX_LAYERED。</param>
        /// <param name="hdcDst">屏幕的设备上下文(DC)句柄;如果指定为空，那么将会在函数调用时自己获得。它用于当窗口内容更新时，与调色板颜色去匹配;如果hdcDst指定为Null，将使用默认调色板;如果hdcSrc为NULL,hdcDst必须NULL。</param>
        /// <param name="pptDst">一个POINT结构的指针(指定新的分层窗口的屏幕位置);如果位置没有改变，pptDst可以为NULL。</param>
        /// <param name="psize">一个尺寸结构的指针(指定分层窗口新的大小);如果不改变窗口大小，psize可以为NULL;如果hdcSrc为NULL，psize必须为NULL。</param>
        /// <param name="hdcSrc">定义了的分层窗口绘图表面的DC句柄;这个句柄可以通过CreateCompatibleDC函数获得;如果窗口的可视范围和形状不发生变化，hdcSrc可以为NULL。</param>
        /// <param name="pptSrc">一个POINT结构的指针(指定了分层窗口在设备上下文的位置);如果hdcSrc为NULL，pptSrc应该是NULL。</param>
        /// <param name="crKey">指向一个COLORREF值(当合成分层窗口时使用指定颜色键值)。要生成COLORREF，使用RGB宏。</param>
        /// <param name="pblend">指向一个BLENDFUNCTION结构(当合成分层窗口时使用指定透明度值)。</param>
        /// <param name="dwFlags">标志参数。</param>
        /// <returns>如果函数成功，返回值为非零;如果函数失败，返回值为零。为了获得更多的错误信息，调用GetLastError。</returns>
        [DllImport("user32.dll", ExactSpelling = false, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UpdateLayeredWindow(IntPtr hWnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pptSrc, uint crKey, [In] ref NativeMethods.BLENDFUNCTION pblend, uint dwFlags);

        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数枚举所有屏幕上的顶层窗口，并将窗口句柄传送给应用程序定义的回调函数。</para>
        /// <para>回调函数返回FALSE将停止枚举，否则EnumWindows函数继续到所有顶层窗口枚举完为止。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>EnumWindows函数不列举子窗口。</para>
        /// <para>在循环体中调用这个函数比调用GetWindow函数更可靠。</para>
        /// <para>调用GetWindow函数中执行这个任务的应用程序可能会陷入死循环或指向一个已被销毁的窗口的句柄。</para>
        /// </summary>
        /// <param name="lpEnumFunc">指向一个应用程序定义的回调函数指针，请参看EnumWindowsProc。</param>
        /// <param name="lParam">指定一个传递给回调函数的应用程序定义值。对象类型需要添加特性ComVisible(true)。</param>
        /// <returns>如果函数成功，返回值为非零；如果函数失败，返回值为零。若想获得更多错误信息，请调用GetLastError函数。</returns>
        [DllImport("User32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumWindows(NativeMethods.EnumWindowsProc lpEnumFunc, object lParam);
        /// <summary>
        /// <para>功能:</para>
        /// <para>EnumChildWindows，通过将句柄传递给每个子窗口并依次传递给应用程序定义的回调函数。</para>
        /// <para>可以枚举属于指定父窗口的子窗口。EnumChildWindows继续，直到枚举最后一个子窗口或回调函数返回FALSE为止。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>如果子窗口创建了自己的子窗口，EnumChildWindows也会枚举这些窗口。</para>
        /// <para>将正确枚举在枚举过程中按Z顺序移动或重新定位的子窗口。</para>
        /// <para>该函数不会枚举在枚举前已销毁或在枚举过程中创建的子窗口。</para>
        /// </summary>
        /// <param name="hWndParent">父窗口的句柄，其子窗口将被枚举。如果此参数为NULL，则此函数等效于EnumWindows。</param>
        /// <param name="lpEnumFunc">指向应用程序定义的回调函数的指针。有关更多信息，请参见EnumChildProc。</param>
        /// <param name="lParam">应用程序定义的值，将传递给回调函数。对象类型需要添加特性ComVisible(true)。</param>
        /// <returns>不使用返回值。</returns>
        [DllImport("User32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumChildWindows(IntPtr hWndParent, NativeMethods.EnumChildProc lpEnumFunc, object lParam);

        #endregion


        #region Window Class Functions                              窗口类函数

        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数返回与指定窗口相关的WNDCLASSEX结构的指定32位值。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>通过使用函数RegisterClassEx将结构WNDCLASSEX中的cbCIsExtra单元指定为一个非O值来保留额外类的存储空间。</para>
        /// <para>Windows CE：nlndex参数是一个字节偏移量，但是必须为 4的倍数。</para>
        /// <para>Windows CE不支持unaligned access。nlndex参数中只可设定为GCL_HICON和GCL_STYLE。</para>
        /// <para>如果使用了Windows CE的 lconsurs组件，该组件支持在适当的目标平台上的鼠标，也可以在nlndex中使用GCL_HCURSOR。</para>
        /// <para>注意支持鼠标的 Windows CE版本包含 Iconcurs和 Mcursor而不是 Icon和 Cursor组件。</para>
        /// </summary>
        /// <param name="hWnd">窗口句柄间接给出的窗口所属的类。</param>
        /// <param name="nIndex">指定要恢复的32位值。从额外的类存储空间恢复一个32位的值，指定的一个大于等于0的被恢复值的偏移量。有效值为从0开始到额外类存储空间字节数一4。例如，若指定了12位或多于12位的额外类存储空间，则应设为第三个32位整数的索引位8。要从WNDCLASSEX结构中恢复任何值，需要指定下面值之一：见GCL</param>
        /// <returns>如果函数成功，返回值是所需的32位值；如果函数失败，返回值为0。若想获得更多错误信息，请调用GetLastError函数。</returns>
        [DllImport("user32.dll", ExactSpelling = false, SetLastError = true)]
        public static extern int GetClassLong(IntPtr hWnd, int nIndex);
        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数替换额外的类存储空间中指定偏移量处的32位长整型值，或替换指定窗口所属类的WNDCLASSEX结构(应该是替换这个结构体中值，没有把结构体给换了吧)。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>如果使用SetClassLong函数和GCL_WNDPROC索引值来替换窗口过程，新的窗口过程必须与WindowProc回调函数中所规定的规则一致。</para>
        /// <para>以带GCL_WNDPROC索引值的SetClassLong函数修改的一个窗口类的的子类将会影响所有随后以该类创建的窗口。应用程序可以创建一个系统类的子类，但是不能创建由其他进程创建的类的子类。</para>
        /// <para>通过使用RegisterClassEx函数将WNDCLASSEX结构中的cbWndExtra单元指定为一个非零值来保留额外的的类存储空间。</para>
        /// <para>使用SetClassLong函数要小心。例如，可以通过使用SetClassLong来改变类的背景颜色，但是这种改变不会马上生效，直到属于该类的窗体下次重绘，除非使用UpdateWindow()强迫窗体更新。</para>
        /// <para>Windows CE：nlndex参数是一个字节偏移量但必须是4的倍数。Unaligned不支持。</para>
        /// <para>不支持在nlndex参数中的标准的CGL_*值，只有一个例外，如果目标设各支持鼠标，则可以在nlndex参数中指定CGL_HCURSOR。</para>
        /// <para>注意支持鼠标的WindowsCE版本包含Iconcurs和Mcursor组件而不是lcon和Cursor组件。</para>
        /// </summary>
        /// <param name="hWnd">窗口句柄及间接给出的窗口所属的类。</param>
        /// <param name="nIndex">指定将被替换的32位值。在额外类存储空间中设置32位值，应指定一个大于或等于0的偏移量。有效值的范围从0到额外类的存储空间的字节数一4；例如，若指定了12个字节或多于12个字节的额外类存储空间，则索引值为8时，对应的是第三个32位整数值。要设置WNDCLASSEX结构中的任何值，指定下面索引之一：见GCL</param>
        /// <param name="dwNewLong">指定的替换值。</param>
        /// <returns>如果函数成功，返回值是原来类结构中32位整数；如果未事先设定，返回值为0。如果函数失败，返回值为0。若想获得更多错误信息，请调用GetLastError函数。</returns>
        [DllImport("user32.dll", ExactSpelling = false, SetLastError = true)]
        public static extern int SetClassLong(IntPtr hWnd, int nIndex, int dwNewLong);

        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数获得有关指定窗口的信息，函数也获得在额外窗口内存中指定偏移位地址的32位度整型值。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>通过使用函数RegisterClassEx将结构WNDCLASSEX中的cbWndExtra单元指定为一个非0值来保留额外类的存储空间。</para>
        /// <para>.</para>
        /// <para>要获得任意其他值，nIndex指定下列值之一：</para>
        /// <para>GWL_EXSTYLE；获得扩展窗口风格。</para>
        /// <para>GWL_STYLE：获得窗口风格。</para>
        /// <para>GWL_WNDPROC：获得窗口过程的地址，或代表窗口过程的地址的句柄。必须使用CallWindowProc函数调用窗口过程。</para>
        /// <para>GWL_HINSTANCE：获得应用事例的句柄。</para>
        /// <para>GWL_HWNDPAAENT：如果父窗口存在，获得父窗口句柄。</para>
        /// <para>GWL_ID:获得窗口标识。</para>
        /// <para>GWL_USERDATA：获得与窗口有关的32位值。每一个窗口均有一个由创建该窗口的应用程序使用的32位值。</para>
        /// <para>.</para>
        /// <para>在hWnd参数标识了一个对话框时，nIndex也可用下列值：</para>
        /// <para>DWL_DLGPROC：获得对话框过程的地址，或一个代表对话框过程的地址的句柄。必须使用函数CallWindowProc来调用对话框过程。</para>
        /// <para>DWL_MSGRESULT：获得在对话框过程中一个消息处理的返回值。</para>
        /// <para>DWL_USER：获得应用程序私有的额外信息，例如一个句柄或指针。</para>
        /// </summary>
        /// <param name="hWnd">窗口句柄及间接给出的窗口所属的窗口类。</param>
        /// <param name="nIndex">指定要获得值的大于等于0的值的偏移量。有效值的范围从0到额外窗口内存空间的字节数一4例如，若指定了12位或多于12位的额外类存储空间，则应设为第三个32位整数的索引位8。</param>
        /// <returns>如果函数成功，返回值是所需的32位值；如果函数失败，返回值是0。</returns>
        [DllImport("user32.dll", ExactSpelling = false)]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数改变指定窗口的属性．函数也将指定的一个32位值设置在窗口的额外存储空间的指定偏移位置。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>如果由hWnd参数指定的窗口与调用线程不属于同一进程，将导致SetWindowLong函数失败。</para>
        /// <para>指定的窗口数据是在缓存中保存的，因此在调用SetWindowLong之后再调用SetWindowPos函数才能使SetWindowLong函数所作的改变生效。</para>
        /// <para>如果使用带GWL_WNDPROC索引值的SetWindowLong函数替换窗口过程，则该窗口过程必须与WindowProccallback函数说明部分指定的指导行一致。</para>
        /// <para>如果使用带DWL_MSGRESULT索引值的SetWindowLong函数来设置由一个对话框过程处理的消息的返回值，应在此后立即返回TRUE。否则，如果又调用了其他函数而使对话框过程接收到一个窗口消息，则嵌套的窗口消息可能改写使用DWL_MSGRESULT设定的返回值。</para>
        /// <para>可以使用带GWL_WNDPROC索引值的SetWindowLong函数创建一个窗口类的子类，该窗口类是用于创建该窗口的类。一个应用程序可以以一个系统类为子类，但是不能以一个其他进程产生的窗口类为子类，SetwindowLong函数通过改变与一个特殊的窗口类相联系的窗口过程来创建窗口子类，从而使系统调用新的窗口过程而不是以前定义的窗口过程。应用程序必须通过调用CallWindowProc函数向前窗口传递未被新窗口处理的消息，这样作允许应用程序创建一个窗口过程链。</para>
        /// <para>通过使用函数RegisterClassEx将结构WNDCLASSEX中的cbWndExtra单元指定为一个非0值来保留新外窗口内存。</para>
        /// <para>不能通过调用带GWL_HWNDPARENT索引值的SetWindowLong的函数来改变子窗口的父窗口，应使用SetParent函数。</para>
        /// <para>.</para>
        /// <para>要设置其他任何值，nIndex可以指定下面值之一：</para>
        /// <para>GWL_EXSTYLE：设定一个新的扩展风格。</para>
        /// <para>GWL_STYLE：设定一个新的窗口风格。</para>
        /// <para>GWL_WNDPROC：为窗口过程设定一个新的地址。</para>
        /// <para>GWL_ID：设置一个新的窗口标识符。</para>
        /// <para>GWL_HINSTANCE：设置一个新的应用程序实例句柄。</para>
        /// <para>GWL_USERDATA：设置与窗口有关的32位值。每个窗口均有一个由创建该窗口的应用程序使用的32位值。</para>
        /// <para>.</para>
        /// <para>当hWnd参数标识了一个对话框时，nIndex也可使用下列值：</para>
        /// <para>DWL_DLGPROC：设置对话框过程的新地址。</para>
        /// <para>DWL_MSGRESULT：设置在对话框过程中处理的消息的返回值。</para>
        /// <para>DWL_USER：设置的应用程序私有的新的额外信息，例如一个句柄或指针。</para>
        /// </summary>
        /// <param name="hWnd">窗口句柄及间接给出的窗口所属的类。</param>
        /// <param name="nIndex">指定将设定的大于等于0的偏移值。有效值的范围从0到额外类的存储空间的字节数减4：例如若指定了12位或多于12位的额外类存储空间，则应设为第三个32位整数的索引位8。</param>
        /// <param name="dwNewLong">指定的替换值。</param>
        /// <returns>如果函数成功，返回值是指定的32位整数的原来的值。如果函数失败，返回值为0。</returns>
        [DllImport("user32.dll", ExactSpelling = false)]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        #endregion


        #region Message Functions                                   消息函数

        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数将指定的消息发送到一个或多个窗口。此函数为指定的窗口调用窗口程序，直到窗口程序处理完消息再返回。</para>
        /// <para>而函数PostMessage不同，将一个消息寄送到一个线程的消息队列后立即返回。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>需要用HWND_BROADCAST通信的应用程序应当使用函数RegisterWindowMessage来为应用程序间的通信取得一个唯一的消息。</para>
        /// <para>如果指定的窗口是由正在调用的线程创建的，则窗口程序立即作为子程序调用。如果指定的窗口是由不同线程创建的，则系统切换到该线程并调用恰当的窗口程序。</para>
        /// <para>线程间的消息只有在线程执行消息检索代码时才被处理。发送线程被阻塞直到接收线程处理完消息为止。</para>
        /// </summary>
        /// <param name="hWnd">其窗口程序将接收消息的窗口的句柄。如果此参数为HWND_BROADCAST，则消息将被发送到系统中所有顶层窗口，包括无效或不可见的非自身拥有的窗口、被覆盖的窗口和弹出式窗口，但消息不被发送到子窗口。</param>
        /// <param name="Msg">指定被发送的消息。</param>
        /// <param name="wParam">指定附加的消息指定信息。</param>
        /// <param name="lParam">指定附加的消息指定信息。</param>
        /// <returns>返回值指定消息处理的结果，依赖于所发送的消息。</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数将指定的消息发送到一个或多个窗口。此函数为指定的窗口调用窗口程序，直到窗口程序处理完消息再返回。</para>
        /// <para>而函数PostMessage不同，将一个消息寄送到一个线程的消息队列后立即返回。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>需要用HWND_BROADCAST通信的应用程序应当使用函数RegisterWindowMessage来为应用程序间的通信取得一个唯一的消息。</para>
        /// <para>如果指定的窗口是由正在调用的线程创建的，则窗口程序立即作为子程序调用。如果指定的窗口是由不同线程创建的，则系统切换到该线程并调用恰当的窗口程序。</para>
        /// <para>线程间的消息只有在线程执行消息检索代码时才被处理。发送线程被阻塞直到接收线程处理完消息为止。</para>
        /// </summary>
        /// <param name="hWnd">其窗口程序将接收消息的窗口的句柄。如果此参数为HWND_BROADCAST，则消息将被发送到系统中所有顶层窗口，包括无效或不可见的非自身拥有的窗口、被覆盖的窗口和弹出式窗口，但消息不被发送到子窗口。</param>
        /// <param name="Msg">指定被发送的消息。</param>
        /// <param name="wParam">指定附加的消息指定信息。</param>
        /// <param name="lParam">指定附加的消息指定信息。</param>
        /// <returns>返回值指定消息处理的结果，依赖于所发送的消息。</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, IntPtr lParam);
        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数将指定的消息发送到一个或多个窗口。此函数为指定的窗口调用窗口程序，直到窗口程序处理完消息再返回。</para>
        /// <para>而函数PostMessage不同，将一个消息寄送到一个线程的消息队列后立即返回。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>需要用HWND_BROADCAST通信的应用程序应当使用函数RegisterWindowMessage来为应用程序间的通信取得一个唯一的消息。</para>
        /// <para>如果指定的窗口是由正在调用的线程创建的，则窗口程序立即作为子程序调用。如果指定的窗口是由不同线程创建的，则系统切换到该线程并调用恰当的窗口程序。</para>
        /// <para>线程间的消息只有在线程执行消息检索代码时才被处理。发送线程被阻塞直到接收线程处理完消息为止。</para>
        /// </summary>
        /// <param name="hWnd">其窗口程序将接收消息的窗口的句柄。如果此参数为HWND_BROADCAST，则消息将被发送到系统中所有顶层窗口，包括无效或不可见的非自身拥有的窗口、被覆盖的窗口和弹出式窗口，但消息不被发送到子窗口。</param>
        /// <param name="Msg">指定被发送的消息。</param>
        /// <param name="wParam">指定附加的消息指定信息。</param>
        /// <param name="lParam">指定附加的消息指定信息。</param>
        /// <returns>返回值指定消息处理的结果，依赖于所发送的消息。</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, string lParam);
        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数将指定的消息发送到一个或多个窗口。此函数为指定的窗口调用窗口程序，直到窗口程序处理完消息再返回。</para>
        /// <para>而函数PostMessage不同，将一个消息寄送到一个线程的消息队列后立即返回。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>需要用HWND_BROADCAST通信的应用程序应当使用函数RegisterWindowMessage来为应用程序间的通信取得一个唯一的消息。</para>
        /// <para>如果指定的窗口是由正在调用的线程创建的，则窗口程序立即作为子程序调用。如果指定的窗口是由不同线程创建的，则系统切换到该线程并调用恰当的窗口程序。</para>
        /// <para>线程间的消息只有在线程执行消息检索代码时才被处理。发送线程被阻塞直到接收线程处理完消息为止。</para>
        /// </summary>
        /// <param name="hWnd">其窗口程序将接收消息的窗口的句柄。如果此参数为HWND_BROADCAST，则消息将被发送到系统中所有顶层窗口，包括无效或不可见的非自身拥有的窗口、被覆盖的窗口和弹出式窗口，但消息不被发送到子窗口。</param>
        /// <param name="Msg">指定被发送的消息。</param>
        /// <param name="wParam">指定附加的消息指定信息。</param>
        /// <param name="lParam">指定附加的消息指定信息。</param>
        /// <returns>返回值指定消息处理的结果，依赖于所发送的消息。</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数将指定的消息发送到一个或多个窗口。此函数为指定的窗口调用窗口程序，直到窗口程序处理完消息再返回。</para>
        /// <para>而函数PostMessage不同，将一个消息寄送到一个线程的消息队列后立即返回。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>需要用HWND_BROADCAST通信的应用程序应当使用函数RegisterWindowMessage来为应用程序间的通信取得一个唯一的消息。</para>
        /// <para>如果指定的窗口是由正在调用的线程创建的，则窗口程序立即作为子程序调用。如果指定的窗口是由不同线程创建的，则系统切换到该线程并调用恰当的窗口程序。</para>
        /// <para>线程间的消息只有在线程执行消息检索代码时才被处理。发送线程被阻塞直到接收线程处理完消息为止。</para>
        /// </summary>
        /// <param name="hWnd">其窗口程序将接收消息的窗口的句柄。如果此参数为HWND_BROADCAST，则消息将被发送到系统中所有顶层窗口，包括无效或不可见的非自身拥有的窗口、被覆盖的窗口和弹出式窗口，但消息不被发送到子窗口。</param>
        /// <param name="Msg">指定被发送的消息。</param>
        /// <param name="wParam">指定附加的消息指定信息。</param>
        /// <param name="lParam">指定附加的消息指定信息。</param>
        /// <returns>返回值指定消息处理的结果，依赖于所发送的消息。</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, ref NativeMethods.RECT lParam);
        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数将指定的消息发送到一个或多个窗口。此函数为指定的窗口调用窗口程序，直到窗口程序处理完消息再返回。</para>
        /// <para>而函数PostMessage不同，将一个消息寄送到一个线程的消息队列后立即返回。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>需要用HWND_BROADCAST通信的应用程序应当使用函数RegisterWindowMessage来为应用程序间的通信取得一个唯一的消息。</para>
        /// <para>如果指定的窗口是由正在调用的线程创建的，则窗口程序立即作为子程序调用。如果指定的窗口是由不同线程创建的，则系统切换到该线程并调用恰当的窗口程序。</para>
        /// <para>线程间的消息只有在线程执行消息检索代码时才被处理。发送线程被阻塞直到接收线程处理完消息为止。</para>
        /// </summary>
        /// <param name="hWnd">其窗口程序将接收消息的窗口的句柄。如果此参数为HWND_BROADCAST，则消息将被发送到系统中所有顶层窗口，包括无效或不可见的非自身拥有的窗口、被覆盖的窗口和弹出式窗口，但消息不被发送到子窗口。</param>
        /// <param name="Msg">指定被发送的消息。</param>
        /// <param name="wParam">指定附加的消息指定信息。</param>
        /// <param name="lParam">指定附加的消息指定信息。</param>
        /// <returns>返回值指定消息处理的结果，依赖于所发送的消息。</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, ref NativeMethods.COPYDATASTRUCT lParam);
        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数将指定的消息发送到一个或多个窗口。此函数为指定的窗口调用窗口程序，直到窗口程序处理完消息再返回。</para>
        /// <para>而函数PostMessage不同，将一个消息寄送到一个线程的消息队列后立即返回。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>需要用HWND_BROADCAST通信的应用程序应当使用函数RegisterWindowMessage来为应用程序间的通信取得一个唯一的消息。</para>
        /// <para>如果指定的窗口是由正在调用的线程创建的，则窗口程序立即作为子程序调用。如果指定的窗口是由不同线程创建的，则系统切换到该线程并调用恰当的窗口程序。</para>
        /// <para>线程间的消息只有在线程执行消息检索代码时才被处理。发送线程被阻塞直到接收线程处理完消息为止。</para>
        /// </summary>
        /// <param name="hWnd">其窗口程序将接收消息的窗口的句柄。如果此参数为HWND_BROADCAST，则消息将被发送到系统中所有顶层窗口，包括无效或不可见的非自身拥有的窗口、被覆盖的窗口和弹出式窗口，但消息不被发送到子窗口。</param>
        /// <param name="Msg">指定被发送的消息。</param>
        /// <param name="wParam">指定附加的消息指定信息。</param>
        /// <param name="lParam">指定附加的消息指定信息。</param>
        /// <returns>返回值指定消息处理的结果，依赖于所发送的消息。</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, ref NativeMethods.TOOLINFO lParam);
        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数将一个消息放入（寄送）到与指定窗口创建的线程相联系消息队列里，不等待线程处理消息就返回，是异步消息模式。</para>
        /// <para>消息队列里的消息通过调用GetMessage和PeekMessage取得。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>需要以 HWND_BROADCAST方式通信的应用程序应当用函数 RegisterwindwosMessage来获得应用程序间通信的独特的消息。</para>
        /// <para>如果发送一个低于WM_USER范围的消息给异步消息函数（PostMessage.SendNotifyMessage，SendMesssgeCallback），消息参数不能包含指针。</para>
        /// <para>否则，操作将会失败。函数将再接收线程处理消息之前返回，发送者将在内存被使用之前释放。</para>
        /// </summary>
        /// <param name="hWnd">其窗口程序接收消息的窗口的句柄。可取有特定含义的两个值：HWND_BROADCAST：消息被寄送到系统的所有顶层窗口，包括无效或不可见的非自身拥有的窗口、被覆盖的窗口和弹出式窗口。消息不被寄送到子窗口。NULL：此函数的操作和调用参数dwThread设置为当前线程的标识符PostThreadMessage函数一样。</param>
        /// <param name="Msg">指定被寄送的消息。</param>
        /// <param name="wParam">指定附加的消息特定的信息。</param>
        /// <param name="lParam">指定附加的消息特定的信息。</param>
        /// <returns>如果函数调用成功，返回非零值：如果函数调用失败，返回值是零。若想获得更多的错误信息，请调用GetLastError函数。</returns>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PostMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数将一个消息放入（寄送）到与指定窗口创建的线程相联系消息队列里，不等待线程处理消息就返回，是异步消息模式。</para>
        /// <para>消息队列里的消息通过调用GetMessage和PeekMessage取得。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>需要以 HWND_BROADCAST方式通信的应用程序应当用函数 RegisterwindwosMessage来获得应用程序间通信的独特的消息。</para>
        /// <para>如果发送一个低于WM_USER范围的消息给异步消息函数（PostMessage.SendNotifyMessage，SendMesssgeCallback），消息参数不能包含指针。</para>
        /// <para>否则，操作将会失败。函数将再接收线程处理消息之前返回，发送者将在内存被使用之前释放。</para>
        /// </summary>
        /// <param name="hWnd">其窗口程序接收消息的窗口的句柄。可取有特定含义的两个值：HWND_BROADCAST：消息被寄送到系统的所有顶层窗口，包括无效或不可见的非自身拥有的窗口、被覆盖的窗口和弹出式窗口。消息不被寄送到子窗口。NULL：此函数的操作和调用参数dwThread设置为当前线程的标识符PostThreadMessage函数一样。</param>
        /// <param name="Msg">指定被寄送的消息。</param>
        /// <param name="wParam">指定附加的消息特定的信息。</param>
        /// <param name="lParam">指定附加的消息特定的信息。</param>
        /// <returns>如果函数调用成功，返回非零值：如果函数调用失败，返回值是零。若想获得更多的错误信息，请调用GetLastError函数。</returns>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PostMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        #endregion


        #region Configuration Reference                             配置参考

        /// <summary>
        /// 检索指定的系统度量或系统配置设置。注意所有检索GetSystemMetrics以像素尺寸。
        /// </summary>
        /// <param name="nIndex">The system metric or configuration setting to be retrieved. This parameter can be one of the following values. Note that all SM_CX* values are widths and all SM_CY* values are heights. Also note that all settings designed to return Boolean data represent TRUE as any nonzero value, and FALSE as a zero value.</param>
        /// <returns>如果函数成功，返回值是所要求的系统度量或配置设置。如果函数失败，返回值是0。则不提供扩展的错误信息。</returns>
        [DllImport("user32.dll")]
        public static extern int GetSystemMetrics(int nIndex);

        #endregion


        #region Error Handling Functions                            错误处理函数

        /// <summary>
        /// <para>功能:</para>
        /// <para>闪烁指定窗口一次。不改变窗口的激活状态。要指定闪烁的时间，使用FlashWindowEx函数。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>Flashing a window means changing the appearance of its caption bar as if the window were changing from inactive to active status, or vice versa. (An inactive caption bar changes to an active caption bar; an active caption bar changes to an inactive caption bar.)</para>
        /// <para>Typically, a window is flashed to inform the user that the window requires attention but that it does not currently have the keyboard focus.</para>
        /// <para>The FlashWindow function flashes the window only once; for repeated flashing, the application should create a system timer.</para>
        /// </summary>
        /// <param name="hWnd">A handle to the window to be flashed. The window can be either open or minimized.</param>
        /// <param name="bInvert">
        /// <para>If this parameter is TRUE, the window is flashed from one state to the other. If it is FALSE, the window is returned to its original state (either active or inactive).</para>
        /// <para>When an application is minimized and this parameter is TRUE, the taskbar window button flashes active/inactive.</para>
        /// <para>If it is FALSE, the taskbar window button flashes inactive, meaning that it does not change colors. It flashes, as if it were being redrawn, but it does not provide the visual invert clue to the user.</para>
        /// </param>
        /// <returns>The return value specifies the window's state before the call to the FlashWindow function. If the window caption was drawn as active before the call, the return value is nonzero. Otherwise, the return value is zero.</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FlashWindow(IntPtr hWnd, bool bInvert);

        /// <summary>
        /// <para>功能:</para>
        /// <para>闪烁指定窗口。不改变窗口的激活状态。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>Typically, you flash a window to inform the user that the window requires attention but does not currently have the keyboard focus.</para>
        /// <para>When a window flashes, it appears to change from inactive to active status. An inactive caption bar changes to an active caption bar; an active caption bar changes to an inactive caption bar.</para>
        /// </summary>
        /// <param name="pfwi">A pointer to a FLASHWINFO structure.</param>
        /// <returns>The return value specifies the window's state before the call to the FlashWindowEx function. If the window caption was drawn as active before the call, the return value is nonzero. Otherwise, the return value is zero.</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FlashWindowEx(ref  NativeMethods.FLASHWINFO pfwi);

        #endregion


        #region Coordinate Space and Transformation Functions       坐标空间变换函数

        /// <summary>
        /// 该函数将指定点的用户坐标转换成屏幕坐标。
        /// </summary>
        /// <param name="hWnd">用户区域用于转换的窗口句柄。</param>
        /// <param name="lpPoint">指向一个含有要转换的用户坐标的结构的指针，如果函数调用成功，新屏幕坐标复制到此结构。</param>
        /// <returns>如果函数调用成功，返回值为非零值，否则为零。</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ClientToScreen(IntPtr hWnd, ref NativeMethods.POINT lpPoint);
        /// <summary>
        /// 该函数将屏幕上指定点的屏幕坐标转换成用户坐标。
        /// </summary>
        /// <param name="hWnd">指向窗口的句柄，此窗口的用户空间将被用来转换。</param>
        /// <param name="lpPoint">指向POINT结构指针，该结构含有要转换的屏幕坐标。</param>
        /// <returns>如果函数调用成功，返回值为非零值，否则为零。</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ScreenToClient(IntPtr hWnd, ref NativeMethods.POINT lpPoint);
        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数把相对于一个窗口的坐标空间的一组点映射成相对于另一窗口的坐标空间的一组点。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>.</para>
        /// </summary>
        /// <param name="hWndFrom">转换点所在窗口的句柄，如果此参数为NULL或HWND_DESETOP则假定这些点在屏幕坐标上。</param>
        /// <param name="hWndTo">转换到的窗口的句柄，如果此参数为NULL或HWND_DESKTOP，这些点被转换为屏幕坐标。</param>
        /// <param name="rect">指向POINT结构数组的指针，此结构数组包含要转换的点，此参数也可指向RECT结构，在此情况下，Cpoints参数应设置为2。</param>
        /// <param name="cPoints">指定rect参数指向的数组中POINT结构的数目。</param>
        /// <returns>如果函数调用成功，返回值的低位字是每一个源点的水平坐标的像素数目，以便计算每个目标点的水平坐标；高位字是每一个源点的垂直坐标的像素的数目，以便计算每个目标点的垂直坐标，如果函数调用失败，返回值为零。</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int MapWindowPoints(IntPtr hWndFrom, IntPtr hWndTo, [In, Out] ref NativeMethods.RECT rect, int cPoints);
        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数把相对于一个窗口的坐标空间的一组点映射成相对于另一窗口的坐标空间的一组点。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>.</para>
        /// </summary>
        /// <param name="hWndFrom">转换点所在窗口的句柄，如果此参数为NULL或HWND_DESETOP则假定这些点在屏幕坐标上。</param>
        /// <param name="hWndTo">转换到的窗口的句柄，如果此参数为NULL或HWND_DESKTOP，这些点被转换为屏幕坐标。</param>
        /// <param name="pt">指向POINT结构数组的指针，此结构数组包含要转换的点，此参数也可指向RECT结构，在此情况下，Cpoints参数应设置为2。</param>
        /// <param name="cPoints">指定pt参数指向的数组中POINT结构的数目。</param>
        /// <returns>如果函数调用成功，返回值的低位字是每一个源点的水平坐标的像素数目，以便计算每个目标点的水平坐标；高位字是每一个源点的垂直坐标的像素的数目，以便计算每个目标点的垂直坐标，如果函数调用失败，返回值为零。</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int MapWindowPoints(IntPtr hWndFrom, IntPtr hWndTo, [In, Out] ref NativeMethods.POINT pt, int cPoints);

        #endregion


        #region Device Context Functions                            设备上下文函数

        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数检索一指定窗口的客户区域或整个屏幕的显示设备上下文环境的句柄，以后可以在GDI函数中使用该句柄来在设备上下文环境中绘图。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>无</para>
        /// </summary>
        /// <param name="hWnd">设备上下文环境被检索的窗口的句柄，如果该值为NULL，GetDC则检索整个屏幕的设备上下文环境。</param>
        /// <returns>如果成功，返回指定窗口客户区的设备上下文环境；如果失败，返回值为Null。</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hWnd);
        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数检索指定窗口客户区域或整个屏幕的显示设备上下文环境的句柄，在随后的GDI函数中可以使用该句柄在设备上下文环境中绘图。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>除非显示设备上下文环境属于一个窗口类，在画图操作之后一定要调用ReleaseDC函数释放设备上下文环境。因为只有5个公用设备上下文环境在任何给定的时间都有效。释放设备上下文环境失败导致其他应用程序不能访问该设备上下文环境。</para>
        /// <para>如果当窗口类注册时，CS_CLASSDC、CS_OWNDC或CS_PARENTDC被指定为WNDCLASS结构的风格，那么该函数返回一个属于该窗口类的设备上下文环境。</para>
        /// <para>.</para>
        /// <para>下列标志可被设置在参数flags里:</para>
        /// <para>DCX_WINDOW：返回与窗口矩形而不是与客户矩形相对应的设备上下文环境。</para>
        /// <para>DXC_CACHE：从高速缓存而不是从OWNDC或CLASSDC窗口中返回设备上下文环境。从本质上覆盖CS_OWNDC和CS_CLASSDC。</para>
        /// <para>DCX_PARENTCLIP：使用父窗口的可见区域，父窗口的WS_CIPCHILDREN和CS_PARENTDC风格被忽略，并把设备上下文环境的原点，设在由hWnd所标识的窗口的左上角。</para>
        /// <para>DCX_CLIPSIBLINGS：排除hWnd参数所标识窗口上的所有兄弟窗口的可见区域。</para>
        /// <para>DCX_CLIPCHILDREN：排除hWnd参数所标识窗口上的所有子窗口的可见区域。</para>
        /// <para>DCX_NORESETATTRS：当设备上下文环境被释放时，并不重置该设备上下文环境的特性为缺省特性。</para>
        /// <para>DCX_LOCKWINDOWUPDATE：即使在排除指定窗口的LockWindowUpdate函数调用有效的情况下也许会绘制，该参数用于在跟踪期间进行绘制。</para>
        /// <para>DCX_EXCLUDERGN：从返回设备上下文环境的可见区域中排除由hrgnClip指定的剪切区域。</para>
        /// <para>DCX_INTERSECTRGN：对hrgnClip指定的剪切区域与返回设备描述的可见区域作交运算。</para>
        /// <para>DCX_VALIDATE：当与DCX_INTERSECTUPDATE一起指定时，致使设备上下文环境完全有效，该函数与DCX_INTERSECTUPDATE和DCX_VALIDATE一起使用时与使用BeginPaint函数相同。</para>
        /// </summary>
        /// <param name="hWnd">窗口的句柄，该窗口的设备上下文环境将要被检索，如果该值为NULL，则GetDCEx将检索整个屏幕的设备上下文环境。</param>
        /// <param name="hrgnClip">指定一剪切区域，它可以与设备上下文环境的可见区域相结合。</param>
        /// <param name="flags">指定如何创建设备上下文环境。</param>
        /// <returns>如果成功，返回值是指定窗口设备上下文环境的句柄，如果失败，返回值为Null。HWnd参数的一个无效值会使函数失败。</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetDCEx(IntPtr hWnd, IntPtr hrgnClip, int flags);
        /// <summary>
        /// <para>功能:</para>
        /// <para>函数释放设备上下文环境（DC）供其他应用程序使用。函数的效果与设备上下文环境类型有关。它只释放公用的和设备上下文环境，对于类或私有的则无效。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>每次调用GetWindowDC和GetDC函数检索公用设备上下文环境之后，应用程序必须调用ReleaseDC函数来释放设备上下文环境。</para>
        /// </summary>
        /// <param name="hWnd">指向要释放的设备上下文环境所在的窗口的句柄。</param>
        /// <param name="hDC">指向要释放的设备上下文环境的句柄。 </param>
        /// <returns>返回值说明了设备上下文环境是否释放；如果释放成功，则返回值为1；如果没有释放成功，则返回值为0。</returns>
        [DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        #endregion


        #region Painting and Drawing Functions                      绘画和绘图函数

        /// <summary>
        /// <para>功能:</para>
        /// <para>BeginPaint函数为指定窗口进行绘图工作的准备，并用将和绘图有关的信息填充到一个PAINTSTRUCT结构中。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>BeginPaint函数自动设置显示设备内容的剪切区域，而排除任何更新区域外的区域。该更新区域可以通过InvalidateRect或InvalidateRgn函数设置，也可以是系统在改变大小、移动、创建、滚动后设置的，</para>
        /// <para>亦是其他的影响客户区的操作来设置的。如果更新区域被标记为可擦除的，BeginPaint发送一个WM_ERASEBKGND消息给窗口。</para>
        /// <para>一个应用程序除了响应WM_PAINT消息外，不应该调用BeginPaint。每次调用BeginPaint都应该有相应的EndPaint函数。</para>
        /// <para>如果被绘画的客户区中有一个caret（caret：插入符。是窗口客户区中的一个闪烁的线，块，或位图。插入符通常表示文本或图形将被插入的地方。即一闪一闪的光标），BeginPaint自动隐藏该符号，而保证它不被擦除。</para>
        /// <para>如果窗口类有一个背景刷，BeginPaint使用这个刷子来擦除更新区域的背景。</para>
        /// </summary>
        /// <param name="hWnd">被重绘的窗口句柄</param>
        /// <param name="lpPaint">指向一个用来接收绘画信息的PAINTSTRUCT结构</param>
        /// <returns>如果函数成功，返回值是指定窗口的“显示设备描述表”句柄。如果函数失败，返回值是NULL，表明没有得到显示设备的内容。Windows NT/2000/XP: 使用GetLastError得到更多的错误信息。</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr BeginPaint(IntPtr hWnd, ref NativeMethods.PAINTSTRUCT lpPaint);
        /// <summary>
        /// <para>功能:</para>
        /// <para>EndPaint函数标记指定窗口的绘画过程结束；</para>
        /// <para>这个函数在每次调用BeginPaint函数之后被请求，但仅仅在绘画完成以后。</para>
        /// </summary>
        /// <param name="hWnd">已经被重画的窗口的HANDLE</param>
        /// <param name="lpPaint">指向一个PAINTSTRUCT结构，该结构包含了绘画信息，是BeginPaint函数返回的返回值：</param>
        /// <returns>返回值始终是非0</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EndPaint(IntPtr hWnd, ref NativeMethods.PAINTSTRUCT lpPaint);

        /// <summary>
        /// <para>功能:</para>
        /// <para>返回hWnd参数所指定的窗口的上下文环境。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>无</para>
        /// </summary>
        /// <param name="hWnd">将要获取上下文环境的窗口的句柄</param>
        /// <returns>如果成功，返回指定窗口客户区的设备上下文环境；如果失败，返回值为Null。</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        /// <summary>
        /// <para>功能:</para>
        /// <para>获取窗口的区域，只有被包含在这个区域内的地方才会被重绘，而不包含在区域内的其他区域系统将不会显示。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>一个窗口的窗口区域的坐标相对于窗口的左上角，而不是在窗口的客户区。</para>
        /// <para>设置窗口的窗口区域，调用SetWindowRgn功能。</para>
        /// </summary>
        /// <param name="hWnd">要设置的窗口句柄。</param>
        /// <param name="hRgn">将被修改的region的句柄。</param>
        /// <returns>返回值指定该函数获得的区域类型。它可以是下列值之一。NULLREGION 参见SCR</returns>
        [DllImport("user32.dll")]
        public static extern int GetWindowRgn(IntPtr hWnd, IntPtr hRgn);
        /// <summary>
        /// <para>功能:</para>
        /// <para>函数设定某一窗口的特定区域（窗口区域）。 这一区域决定了该窗口中系统可以画图的范围。 系统不显示该窗口这一区域之外的任何部分。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>当该函数被调用的时候，系统把给窗口的讯息送给 WM_WINDOWPOSCHANGING 和 WM_WINDOWPOSCHANGED 。</para>
        /// <para>一个窗户的窗口区域的坐标相对于窗口的上面-左边角落而不是窗口的客户区域。</para>
        /// <para>调用成功之后，对 SetWindowRgn ，系统拥有被区域柄 hRgn 指定的区域。 系统不作区域的副本。 因此，你不应该用这一个区域柄来做任何的较进一步的方法调用。 尤其，不要删除这一个区域句柄。 当它不再需要的时候，系统划除这一区域句柄。</para>
        /// <para>为了要获得窗口的窗口区域，调用 GetWindowRgn 函数。</para>
        /// </summary>
        /// <param name="hWnd">将被设定窗口区域的某一窗口的柄。</param>
        /// <param name="hRgn">窗口区域的句柄。函数将窗户的窗户区域设定为这一个区域。如果 hRgn 是无效力的，函数将窗口区域设定为零。</param>
        /// <param name="bRedraw">指定系统是否在设定窗户区域之后重绘窗口。如果 bRedraw 为TRUE，系统重绘; 否则，不重绘。</param>
        /// <returns>如果函数调用成功，回返价值是非零。如果函数调用失败，回返价值是零。</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool bRedraw);

        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数向指定的窗体更新区域添加一个矩形，然后窗口客户区域的这一部分将被重新绘制。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>被标记为无效矩形的区域直到WM_PAINT消息被处理完之后才会消失，或者使用ValidateRect()，ValidateRgn()函数来使之有效。</para>
        /// <para>当应用程序的消息队列中为空时，并且窗体要更新的区域非空时，系统会发送一个WM_PAINT消息到窗体。</para>
        /// </summary>
        /// <param name="hWnd">要更新的客户区所在的窗体的句柄。如果为NULL，则系统将在函数返回前重新绘制所有的窗口, 然后发送 WM_ERASEBKGND 和 WM_NCPAINT 给窗口过程处理函数。</param>
        /// <param name="lpRect">无效区域的矩形代表，它是一个结构体指针，存放着矩形的大小。如果为NULL，全部的窗口客户区域将被增加到更新区域中。</param>
        /// <param name="bErase">指出无效矩形被标记为有效后，是否重画该区域，重画时用预先定义好的画刷。当指定TRUE时需要重画。</param>
        /// <returns>函数成功则返回非零值，否则返回零值。</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);
        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数向指定的窗体更新区域添加一个矩形，然后窗口客户区域的这一部分将被重新绘制。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>被标记为无效矩形的区域直到WM_PAINT消息被处理完之后才会消失，或者使用ValidateRect()，ValidateRgn()函数来使之有效。</para>
        /// <para>当应用程序的消息队列中为空时，并且窗体要更新的区域非空时，系统会发送一个WM_PAINT消息到窗体。</para>
        /// </summary>
        /// <param name="hWnd">要更新的客户区所在的窗体的句柄。如果为NULL，则系统将在函数返回前重新绘制所有的窗口, 然后发送 WM_ERASEBKGND 和 WM_NCPAINT 给窗口过程处理函数。</param>
        /// <param name="lpRect">无效区域的矩形代表，它是一个结构体指针，存放着矩形的大小。如果为NULL，全部的窗口客户区域将被增加到更新区域中。</param>
        /// <param name="bErase">指出无效矩形被标记为有效后，是否重画该区域，重画时用预先定义好的画刷。当指定TRUE时需要重画。</param>
        /// <returns>函数成功则返回非零值，否则返回零值。</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool InvalidateRect(IntPtr hWnd, ref NativeMethods.RECT lpRect, bool bErase);
        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数通过添加一个区域到一个窗口的更新区域中来使指定矩形的客户区域无效；</para>
        /// <para>这个无效的区域和所有更新区域中的其他区域将被标记用来在下一个WM_PAINT消息发生的时候描绘。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>无效的区域被累积，直到下个WM_PAINT消息被处理或着通过ValidateRect或ValidateRgn来使区域变有效。</para>
        /// <para>系统发送一个WM_PAINT消息给到一个窗口，无论窗口的更新区域是不是空的，有没有其他的消息在窗口的应用程序队列中。</para>
        /// <para>指定的区域必须已经通过一个区域函数创建了。</para>
        /// <para>如果更新区域中任何部分的bErase参数是TRUE，整个区域的背景都被擦除，而不是指定的那部分。</para>
        /// </summary>
        /// <param name="hWnd">更新区域被修改的窗口句柄</param>
        /// <param name="hRgn">被添加到更新区域的区域的句柄；这个区域被假定有一个客户区坐标。如果这个参数是NULL，整个客户区都被添加进更新区域。</param>
        /// <param name="bErase">说明当更新区域被处理的时候更新区域内的背景是否要擦除。如果这个参数是TRUE，当BeginPaint函数被调用的时候背景将被擦除，如果参数是FALSE，背景不会改变。</param>
        /// <returns>返回值总是非零。</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool InvalidateRgn(IntPtr hWnd, IntPtr hRgn, bool bErase);
        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数更新指定窗口的无效矩形区域，使之有效。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>BeginPaint函数会自动使全部客户区生效。</para>
        /// <para>如果在下一个WM_PAINT消息产生之前，一个区域的的更新区域必须有效，那么不要调用ValidateRect或ValidateRgn函数。</para>
        /// <para>否则系统继续产生WM_PAINT 消息直到当前的更新区域生效。</para>
        /// </summary>
        /// <param name="hWnd">标识一个想要修改状态的窗口。若该参数为NULL, 系统将更新所有的窗口，然后在函数返回前发送 WM_ERASEBKGND 和 WM_NCPAINT 消息给窗口过程处理函数。</param>
        /// <param name="lpRect">指向一个包含需要生效的矩形的更新区域坐标的RECT 结构体。如果该参数为NULL，所有的客户区域将会生效。</param>
        /// <returns>成功执行返回非零值，否则返回零值。</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ValidateRect(IntPtr hWnd, ref NativeMethods.RECT lpRect);
        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数更新指定窗口的无效矩形区域，使之有效。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>BeginPaint函数会自动使全部客户区生效。</para>
        /// <para>如果在下一个WM_PAINT消息产生之前，一个区域的的更新区域必须有效，那么不要调用ValidateRect或ValidateRgn函数。</para>
        /// <para>否则系统继续产生WM_PAINT 消息直到当前的更新区域生效。</para>
        /// </summary>
        /// <param name="hWnd">标识一个想要修改状态的窗口。若该参数为NULL, 系统将更新所有的窗口，然后在函数返回前发送 WM_ERASEBKGND 和 WM_NCPAINT 消息给窗口过程处理函数。</param>
        /// <param name="lpRect">指向一个包含需要生效的矩形的更新区域坐标的RECT 结构体。如果该参数为NULL，所有的客户区域将会生效。</param>
        /// <returns>成功执行返回非零值，否则返回零值。</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ValidateRect(IntPtr hWnd, IntPtr lpRect);
        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数更新指定窗口的无效区域，使之有效。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>BeginPaint函数会自动使全部客户区生效。</para>
        /// <para>如果在下一个WM_PAINT消息产生之前，一个区域的的更新区域必须有效，那么不要调用ValidateRect或ValidateRgn函数。</para>
        /// <para>否则系统继续产生WM_PAINT 消息直到当前的更新区域生效。</para>
        /// </summary>
        /// <param name="hWnd">标识一个想要修改状态的窗口。</param>
        /// <param name="hRgn">要移除的区域的句柄。如果该参数为NULL，所有的客户区域将会生效。</param>
        /// <returns>成功执行返回非零值，否则返回零值。</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ValidateRgn(IntPtr hWnd, IntPtr hRgn);

        /// <summary>
        /// <para>功能:</para>
        /// <para>如果窗口更新的区域不为空，UpdateWindow函数通过发送一个WM_PAINT消息来更新指定窗口的客户区。</para>
        /// <para>函数绕过应用程序的消息队列，直接发送WM_PAINT消息给指定窗口的窗口过程，如果更新区域为空，则不发送消息。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// </summary>
        /// <param name="hWnd">要更新的窗口的句柄.</param>
        /// <returns>如果函数调用成功，返回值为非零值。如果函数调用不成功，返回值为零。在Windows NT/2000/XP中，我们可以使用API 函数 GetLastError 来得到扩展的错误信息。</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UpdateWindow(IntPtr hWnd);

        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数重绘全部或部分窗口区域。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>如针对桌面窗口应用这个函数，则应用程序必须用RDW_ERASE旗标重画桌面。</para>
        /// </summary>
        /// <param name="hWnd">要重画的窗口的句柄。零表示更新桌面窗口</param>
        /// <param name="lprcUpdate">窗口中需要重画的一个矩形区域。如果hrgnUpdate参数识别，将忽略此参数。</param>
        /// <param name="hrgnUpdate">窗口中要重绘的剪切区域。</param>
        /// <param name="flags">规定具体重画操作的标识。</param>
        /// <returns>如果函数调用成功，返回值为非零值。如果函数调用不成功，返回值为零。在Windows NT/2000/XP中，我们可以使用API 函数 GetLastError 来得到扩展的错误信息。</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, int flags);
        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数重绘全部或部分窗口区域。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>如针对桌面窗口应用这个函数，则应用程序必须用RDW_ERASE旗标重画桌面。</para>
        /// </summary>
        /// <param name="hWnd">要重画的窗口的句柄。零表示更新桌面窗口</param>
        /// <param name="lprcUpdate">窗口中需要重画的一个矩形区域。如果hrgnUpdate参数识别，将忽略此参数。</param>
        /// <param name="hrgnUpdate">窗口中要重绘的剪切区域。</param>
        /// <param name="flags">规定具体重画操作的标识。</param>
        /// <returns>如果函数调用成功，返回值为非零值。如果函数调用不成功，返回值为零。在Windows NT/2000/XP中，我们可以使用API 函数 GetLastError 来得到扩展的错误信息。</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RedrawWindow(IntPtr hWnd, ref NativeMethods.RECT lprcUpdate, IntPtr hrgnUpdate, int flags);

        #endregion


        #region Keyboard Input Functions                            键盘输入函数

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetActiveWindow();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr SetActiveWindow(IntPtr hWnd);


        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数用于判断指定的窗口是否允许接受键盘或鼠标输入。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>子窗口只有在被允许并且可见时才可接受输入。</para>
        /// </summary>
        /// <param name="hWnd">被测试的窗口句柄。</param>
        /// <returns>若窗口允许接受键盘或鼠标输入，则返回非零值，若窗口不允许接受键盘或鼠标输入，则返回值为零。</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWindowEnabled(IntPtr hWnd);
        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数允许/禁止指定的窗口或控件接受鼠标和键盘的输入，当输入被禁止时，窗口不响应鼠标和按键的输入，输入允许时，窗口接受所有的输入。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>若窗口的允许状态将发生变化，WM_ENABLE消息将在Enblewindow函数返回前发送出去，若窗口已被禁止，它所有的子窗口也被禁止，尽管并未向子窗口发送WM_ENABLE消息。</para>
        /// <para>窗口被激活前必须处于允许状态。比如，一个应用程序将显示一个无模式对话框并且已使该对话框的主窗口处于禁止状态，则在撤消该对话框之前须使其主窗口处于允许状态。否则，其他窗口将接受并被激活。若子窗口被禁止，则系统决定由哪个窗口接受鼠标消息时将忽略该窗口</para>
        /// <para>缺省情况下，窗口被创建时被置为允许。若创建一个初始化为禁止状态的窗口，应用程序需要在CeateWindow或CeateWindowEX函数中定义WS_DISABLED样式。窗口创建后，应用程序可用EnbleWindow来允许禁止窗口。</para>
        /// <para>应用程序可利用此函数允许/禁止对话框中的某个控件，被禁止的控件既不能接受键盘输入，也不能被用户访问。</para>
        /// </summary>
        /// <param name="hWnd">被允许/禁止的窗口句柄</param>
        /// <param name="bEnable">定义窗口是被允许，还是被禁止。若该参数为TRUE，则窗口被允许。若该参数为FALSE，则窗口被禁止。</param>
        /// <returns>在 EnableWindow 成员函数调用之前，指示状态。如果窗口此前已禁用，则返回值是非零。如果窗口此前未禁用，则返回值是零。</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnableWindow(IntPtr hWnd, bool bEnable);

        /// <summary>
        /// <para>功能:</para>
        /// <para>检索具有键盘焦点的窗口的句柄,如果窗口连接到调用线程的消息队列。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>GetFocus返回键盘焦点的窗口为当前线程的消息队列。如果GetFocus返回NULL,另一个线程的队列可能连接到键盘焦点的一个窗口。</para>
        /// <para>使用GetForegroundWindow函数来检索处理用户当前工作的窗口。你可以将你的线程的消息队列与窗户由另一个线程使用AttachThreadInput功能。</para>
        /// <para>获得键盘焦点的窗口前台队列或另一个线程的队列,使用GetGUIThreadInfo功能。</para>
        /// </summary>
        /// <returns>返回值是键盘焦点的窗口的句柄。如果调用线程的消息队列没有与键盘焦点相关的窗口,返回值是NULL。</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetFocus();
        /// <summary>
        /// <para>功能:</para>
        /// <para>键盘焦点设置为指定的窗口。窗户必须附加到调用线程的消息队列。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>SetFocus函数发送一个WM_KILLFOCUS消息丢失键盘焦点的窗口和一个WM_SETFOCUS消息接收键盘焦点的窗口。同时激活窗口,接收焦点或父窗口的接收焦点。</para>
        /// <para>如果一个窗口是活跃但没有焦点,任意键按下就会产生WM_SYSCHAR,WM_SYSKEYDOWN,或WM_SYSKEYUP消息。如果还敦促VK_MENU键,消息的lParam参数将有点30集。否则,没有这一点产生的消息。</para>
        /// <para>通过使用AttachThreadInput函数,一个线程可以将其输入处理附加到另一个线程。这允许一个线程调用SetFocus设置键盘焦点窗口连接到另一个线程的消息队列。</para>
        /// </summary>
        /// <param name="hWnd">窗口的句柄,将接收键盘输入。如果这个参数是NULL,按键被忽略。</param>
        /// <returns>如果函数成功,返回值是处理以前的窗口中键盘焦点。如果hWnd参数无效或窗口不附加到调用线程的消息队列,返回值是NULL。扩展的错误信息,调用GetLastError.</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr SetFocus(IntPtr hWnd);

        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数检取指定虚拟键的状态。</para>
        /// <para>该状态指定此键是UP状态，DOWN状态，还是被触发的（开关每次按下此键时进行切换）。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>当给定线程从它的消息队列中读键消息时，该函数返回的键状态发生改变。该状态并不反映与硬件相关的中断级的状态。使用GetAsyncKeyState可获取这一信息。</para>
        /// <para>应用程序可以使用GetKeyState来响应一个由键盘输入产生的消息。此时该程序获得的是在输入消息生成时该键位的状态。</para>
        /// <para>欲检取所有虚拟键状态信息，可以使用GetKeyboardState函数。</para>
        /// <para>应用程序可以使用虚拟键码常数VK_SHIFT，VK_CONTROL和VK_MENU作为nVirtKey参数的值。它给出shift，ctrl或alt键的值而不区分左右键，应用程序也可以使用如下的虚拟键码常数作nVirtKey的值来区分前述键的左键、右键的情形。</para>
        /// <para>VK_LSHIFT，VK_RSHIFT；VK_LCONTROL，VK_RCONTROL；VK_LMENU，VK_RMENU。</para>
        /// <para>仅当应用程序调用GetKeyboardSlate，SetKeyboardState，GetAsyncKeystate；GetKeyState和MapVirtualKey函数时，才可用这些区分左右键的常数。</para>
        /// <para>Windows CE：GetKeyState函数仅能用于检查如下虚拟键的DOWN状态。</para>
        /// <para>VK_LSHIFT，VKRSHIFT，VK_LCONTROL；VK_RCONTROL；VK_LMENU，VK_RMENU。</para>
        /// <para>GetKeyState函数只能用于检查VK_CAPITAL虚拟键的触发状态。</para>
        /// </summary>
        /// <param name="nVirtKey">定义一虚拟键。若要求的虚拟键是字母或数字（A～Z，a～z或0～9），nVirtKey必须被置为相应字符的ASCII码值，对于其他的键，nVirtKey必须是一虚拟键码。若使用非英语键盘布局，则取值在ASCIIa～z和0～9的虚拟键被用于定义绝大多数的字符键。例如，对于德语键盘格式，值为ASCII0（OX4F）的虚拟键指的是"0"键，而VK_OEM_1指"带变音的0键"</param>
        /// <returns>若高序位为1，则键处于DOWN状态，否则为UP状态。若低序位为1，则键被触发。例如CAPS LOCK键，被找开时将被触发。若低序位置为0，则键被关闭，且不被触发。触发键在键盘上的指示灯，当键被触发时即亮，键不被触发时即灭。</returns>
        [DllImport("user32.dll")]
        public static extern short GetKeyState(int nVirtKey);
        /// <summary>
        /// 该函数合成键盘事件和鼠标事件，用来模拟鼠标或者键盘操作。事件将被插入在鼠标处理队列里面。
        /// </summary>
        /// <param name="nInputs">指定ninput 数组中元素的个数。就是插入事件的个数。</param>
        /// <param name="pInputs">指向一个类型为INPUT的数组变量，该数组中的每个元素代表一个将要插入到线程事件中去的键盘或鼠标事件。</param>
        /// <param name="cbSize">指定INPUT结构的大小。如果cbSize不是INPUT结构的大小，则函数将失败返回。</param>
        /// <returns>成功插入了多少个操作事件。如果插入出错可以利用GetLastError来查看错误类型。</returns>
        [DllImport("User32.dll")]
        public static extern uint SendInput(uint nInputs, NativeMethods.INPUT[] pInputs, int cbSize);

        /// <summary>
        /// 该函数可以获得与系统中输入点的当前集相对应的键盘布局句柄。该函数将句柄拷贝到指定的缓冲区中。
        /// </summary>
        /// <param name="nBuff">指定缓冲区中可以存放的最大句柄数目。</param>
        /// <param name="lpList">缓冲区指针，缓冲区中存放着键盘布局句柄数组。</param>
        /// <returns>若函数调用成功，则返回值为拷贝到缓冲区的键盘布局句柄的数目，或者，若nBuff为0，则运回值为接受所有当前键盘布局的缓冲区中的大小（以数组成员为单位）。若函数调用失败，返回值为0。若想获得更多错误信息，可调用GetLastError函数。</returns>
        [DllImport("user32")]
        public static extern int GetKeyboardLayoutList(int nBuff, IntPtr[] lpList);
        /// <summary>
        /// 该函数可以获得指定线程的活动键盘布局。若idThread参数为零，将返回活动线程的键盘布局。
        /// </summary>
        /// <param name="idThread">标识欲查询的线程标识符，当前线程标识符为0。</param>
        /// <returns>返回值为指定线程的键盘布局句柄。返回值的低位字包含了输入语言的语言标识符，高位字包含了键盘物理布局的句柄。</returns>
        [DllImport("user32")]
        public static extern IntPtr GetKeyboardLayout(int idThread);
        /// <summary>
        /// 激活键盘布局。该函数Windows NT和Windows 95中的实现有很大不同。本参考页中首先给出了完整的Windows NT的实现，下来又给出了Windows 95版本的实现，以便大家更好地了解二者的区别。在Windows NT中ActivateKeyboadLayout函数激活一种不同的键盘布局，同时在整个系统中而不仅仅是调用该函数的进程中将该键盘布局设为活动的。
        /// </summary>
        /// <param name="hkl">将被激活的键盘布局的句柄。在Windows NT/2000/XP下，该布局必须先调用LoadKeyboadLayout函数装入，该参数必须是键盘分局的句柄，或是如下的值中的一种：</param>
        /// <param name="Flags">定义键盘布局如何被激活。该参数可取如下的一些值：</param>
        /// <returns>如果函数调用成功，返回值为前一键盘布局的句柄。否则，返回值为零。若要获得更多多错误信息，可调用GetLastError函数。</returns>
        [DllImport("user32")]
        public static extern uint ActivateKeyboardLayout(IntPtr hkl, uint Flags);

        #endregion


        #region Mouse Input Functions                               鼠标输入函数

        /// <summary>
        /// 该函数取得鼠标的当前双击时间。一次双击是指对鼠标键的两次连击，第一次击键后在指定时间内击第二次。双击时间是指在双击中，第一次击键和第二次击键之间的最大毫秒数。
        /// </summary>
        /// <returns>返回是当前双击时间，按毫秒计算。</returns>
        [DllImport("user32.dll", EntryPoint = "GetDoubleClickTime")]
        public static extern int GetDoubleClickTime();

        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数取得捕获了鼠标的窗口（如果存在）的句柄。在同一时刻，只有一个窗口能捕获鼠标；此时，该窗口接收鼠标的输入，无论光标是否在其范围内。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>返回NULL并不意味着系统里没有其他进程或线程捕获到鼠标，只表示当前线程没有捕获到鼠标。</para>
        /// </summary>
        /// <returns>返回值是与当前线程相关联的捕获窗口的句柄。如果当前线程里没有窗口捕获到鼠标，则返回NULL。</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetCapture();
        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数在属于当前线程的指定窗口里设置鼠标捕获。</para>
        /// <para>一旦窗口捕获了鼠标，所有鼠标输入都针对该窗口，无论光标是否在窗口的边界内。</para>
        /// <para>同一时刻只能有一个窗口捕获鼠标。</para>
        /// <para>如果鼠标光标在另一个线程创建的窗口上，只有当鼠标键按下时系统才将鼠标输入指向指定的窗口。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>只有前台窗口才能捕获鼠标。</para>
        /// <para>如果一个后台窗口想捕获鼠标，则该窗口仅为其光标热点在该窗口可见部份的鼠标事件接收消息。</para>
        /// <para>另外，即使前台窗口已捕获了鼠标，用户也可点击另一个窗口，将其调入前台。</para>
        /// <para>当一个窗口不再需要所有的鼠标输入时，创建该窗口的线程应当调用函数ReleaseCapture来释放鼠标。</para>
        /// <para>此函数不能被用来捕获另一进程的鼠标输入。</para>
        /// </summary>
        /// <param name="hWnd">当前线程里要捕获鼠标的窗口句柄。</param>
        /// <returns>返回值是上次捕获鼠标的窗口句柄。如果不存在那样的句柄，返回值是NULL。</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr SetCapture(IntPtr hWnd);
        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数从当前线程中的窗口释放鼠标捕获，并恢复通常的鼠标输入处理。</para>
        /// <para>捕获鼠标的窗口接收所有的鼠标输入（无论光标的位置在哪里），除非点击鼠标键时，光标热点在另一个线程的窗口中。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>应用程序在调用函数SetCaPture之后调用此函数。</para>
        /// </summary>
        /// <returns>如果函数调用成功，返回非零值；如果函数调用失败，返回值是零。</returns>
        [DllImport("user32.DLL")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReleaseCapture();

        #endregion


        #region Cursor Functions                                    光标函数

        /// <summary>
        /// 获取全局贯标信息
        /// </summary>
        /// <param name="pci">A pointer to a CURSORINFO structure that receives the information. Note that you must set the cbSize member to sizeof(CURSORINFO) before calling this function.</param>
        /// <returns>If the function succeeds, the return value is nonzero.If the function fails, the return value is zero. To get extended error information, call GetLastError.</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCursorInfo(out NativeMethods.CURSORINFO pci);
        /// <summary>
        /// 该函数显示或隐藏光标。该函数设置了一个内部显示计数器以确定光标是否显示，仅当显示计数器的值大于或等于0时，光标才显示，如果安装了鼠标，则显示计数的初始值为0。如果没有安装鼠标，显示计数是C1。
        /// </summary>
        /// <param name="bShow">确定内部的显示计数器是增加还是减少，如果bShow为TRUE，则显示计数器增加1，如果bShow为FALSE，则计数器减1。</param>
        /// <returns>返回值规定新的显示计数器。</returns>
        [DllImport("user32.dll")]
        public static extern int ShowCursor(bool bShow);

        #endregion


        #region Menu Functions                                      菜单函数

        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数允许应用程序为复制或修改而访问窗口菜单（系统菜单或控制菜单）。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>任何没有用函数GetSystemMenu来生成自己的窗口菜单拷贝的窗口将接受标准窗口菜单。</para>
        /// <para>窗口某单最初包含的菜单项有多种标识符值，如SC_CLOSE，SC_MOVE和SC_SIZE。</para>
        /// <para>窗口菜单上的菜单项发送WM_SYSCOMMAND消息。</para>
        /// <para>所有预定义的窗口菜单项的标识符数大于OxFOOO。如果一个应用程序增加命令到窗口菜单，应该使用小于OxFOOO的标识符数。</para>
        /// <para>系统根据状态自动变灰标准窗口菜单上的菜单项。应用程序通过响应在任何某单显示之前发送的WM_INITMENU消息来实现选取和变灰。</para>
        /// <para>Windows CE环境下，不支持系统菜单，但GetSyemMenu以宏的方式实现，以保持和已存在代码的兼容性。可以使用该宏的返回菜单句柄使关闭框无效，与在Windows桌面平台上一样。Windows CE下的返回值没有其他用处。参数bRevert无用。</para>
        /// <para>用下面的代码使关闭按钮无效：</para>
        /// <para>EnableMenultem（GetSystemMenu（hwnd，FALSE），SC_CLOSE，MF_BYCOMMAND I MF_GRAYED）；</para>
        /// </summary>
        /// <param name="hWnd">拥有窗口菜单拷贝的窗口的句柄。</param>
        /// <param name="bRevert">指定将执行的操作。如果此参数为FALSE，GetSystemMenu返回当前使用窗口菜单的拷贝的句柄。该拷贝初始时与窗口菜单相同，但可以被修改。如果此参数为TRUE，GetSystemMenu重置窗口菜单到缺省状态。如果存在先前的窗口菜单，将被销毁。</param>
        /// <returns>如果参数bRevert为FALSE，返回值是窗口菜单的拷贝的句柄：如果参数bRevert为TRUE，返回值是NULL。</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数在指定的菜单条、下拉式菜单、子菜单或快捷菜单的末尾追加一个新菜单项。</para>
        /// <para>此函数可指定菜单项的内容、外观和性能。函数AppendMenu己被lnsertMenultem取代。</para>
        /// <para>但如果不需要lnsertMenultem的扩展特性，仍可使用AppendMenu。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>一旦菜单被修改，无论它是否在显示窗口里，应用程序必须调用函数DrawMenuBar。</para>
        /// <para>为了使键盘加速键能控制位留或自己绘制的菜单项，菜单的拥有者必须处理WM_MENUCHAR消息。</para>
        /// <para>参见自绘制菜单和WM_MENUCHAR消息。</para>
        /// <para>下列标志可被设置在参数uFlags里：</para>
        /// <para>MF_BITMAP：将一个位图用作菜单项。参数lpNewltem里含有该位图的句柄。</para>
        /// <para>MF_CHECKED：在菜单项旁边放置一个选取标记。如果应用程序提供一个选取标记，位图（参见SetMenultemBitmaps），则将选取标记位图放置在菜单项旁边。</para>
        /// <para>MF_DISABLED：使菜单项无效，使该项不能被选择，但不使菜单项变灰。</para>
        /// <para>MF_ENABLED：使菜单项有效，使该项能被选择，并使其从变灰的状态恢复。</para>
        /// <para>MF_GRAYED：使菜单项无效并变灰，使其不能被选择。</para>
        /// <para>MF_MENUBARBREAK：对菜单条的功能同MF_MENUBREAK标志。对下拉式菜单、子菜单或快捷菜单，新列和旧列被垂直线分开。</para>
        /// <para>MF_MENUBREAK：将菜单项放置于新行（对菜单条），或新列（对下拉式菜单、子菜单或快捷菜单）且无分割列。</para>
        /// <para>MF_OWNERDRAW：指定该菜单项为自绘制菜单项。菜单第一次显示前，拥有菜单的窗口接收一个WM_MEASUREITEM消息来得到菜单项的宽和高。然后，只要菜单项被修改，都将发送WM_DRAWITEM消息给菜单拥有者的窗口程序。</para>
        /// <para>MF_POPUP：指定菜单打开一个下拉式菜单或子菜单。参数uIDNewltem下拉式菜单或子菜单的句柄。此标志用来给菜单条、打开一个下拉式菜单或于菜单的菜单项、子菜单或快捷菜单加一个名字。</para>
        /// <para>MF_SEPARATOR：画一条水平区分线。此标志只被下拉式菜单、子菜单或快捷菜单使用。此区分线不能被变灰、无效或加亮。参数IpNewltem和uIDNewltem无用。</para>
        /// <para>MF_STRING：指定菜单项是一个正文字符串；参数lpNewltem指向该字符串。</para>
        /// <para>MF_UNCHECKED：不放置选取标记在菜单项旁边（缺省）。如果应用程序提供一个选取标记位图（参见SetMenultemBitmaps），则将选取标记位图放置在菜单项旁边。</para>
        /// <para>下列标志组不能被一起使用：</para>
        /// <para>MF_DISABLED，MF_ENABLED和MF_GRAYED；MF_BITMAP,MF_STRING和MF_OWNERDRAW</para>
        /// <para>MF_MENUBARBREAK和MF_MENUBREAK；MF_CHECKED和MF_UNCHECKED</para>
        /// <para>Windows CE环境下，不支持参数fuFlags使用下列标志：</para>
        /// <para>MF_BITMAP；MF_DOSABLE；MF_GRAYED</para>
        /// <para>MF_GRAYED可用来代替MF_DISABLED和MFS_GRAYED。</para>
        /// <para>Windows CE 1.0不支持层叠式菜单。在使用Windows CE 1.0时，不能将一个MF_POPUP菜单插入到另一个下拉式菜单中。Window CE 1.0不支持下列标志：</para>
        /// <para>MF_POPUP；MF_MENUBREAK；MF_MENUBARBREAK</para>
        /// <para>Windows CE 2.0或更高版本中，支持上述标志，也支持层叠式菜单。</para>
        /// </summary>
        /// <param name="hMenu">将被修改的菜单条、下拉式菜单、子菜单、或快捷菜单的句柄。</param>
        /// <param name="uFlags">控制新菜单项的外观和性能的标志。此参数可以是备注里所列值的组合。</param>
        /// <param name="uIDNewltem">指定新菜单项的标识符，或者当uFlags设置为MF_POPUP时，表示下拉式菜单或子菜单的句柄。</param>
        /// <param name="lpNewltem">指定新菜单项的内容。此参数的含义取决于参数uFlags是否包含MF_BITMAP, MF_OWNERDRAW或MF_STRING标志，如下所示：MF_BITMAP：含有位图句柄。MF_STRING：以`\O’结束的字符串的指针。MF_OWNERDRAW：含有被应用程序应用的32位值，可以保留与菜单项有关的附加数据。当菜单被创建或其外观被修改时，此值在消息WM_MEASURE或WM_DRAWITEM的参数IParam指向的结构，成员itemData里。</param>
        /// <returns>如果函数调用成功，返回非零值；如果函数调用失败，返回值是零。若想获得更多的错误信息，请调用GetLastError函数。</returns>
        [DllImport("user32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AppendMenu(IntPtr hMenu, uint uFlags, uint uIDNewltem, string lpNewltem);
        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数插入一个新菜单项到菜单里，并使菜单里其他项下移。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>一旦菜单被修改，无论它是否在显示窗口里，应用程序必须调用函数DrawMenuBar。</para>
        /// </summary>
        /// <param name="hMenu">将被修改的菜单的句柄。</param>
        /// <param name="uPosition">指定新菜单项将被插入其前面的菜单项，其含义由参数uFlagS决定。</param>
        /// <param name="uFlags">指定控制参数uPosition的解释的标志、新菜单项的内容、外观和性能。此参数必须为下列值之一和列于备注里的一个值的组合。MF_BYCOMMAND：表示uPosition给出菜单项的标识符。如果MF_BYCOMMAND和MF_BYPOSITION都没被指定，则MF_BYCOMMAND为缺省的标志。MF_BYPOSITION：表示uPosition给出新菜单项基于零的相对位置。如果uPosition为OxFFFFFFFF新菜单项追加于菜单的末尾。</param>
        /// <param name="uIDNewItem">指定新菜单项的标识符，或者当参数uFlags设置为MF_POPUP时，指定下拉式菜单或子菜单的句柄。</param>
        /// <param name="lpNewItem">指定新菜单项的内容。其含义依赖于参数UFlags是否包含标志MF_BITMAP,MF_OWNERDRAW或MF_STRING。如下所示：MF_BITMAP：含有位图句柄。MF_STRING：以`\0’结束的字符串的指针（缺省）。MF_OWNERDRAW：含有被应用程序应用的32位值，可以保留与菜单项有关的附加数据。当菜单被创建或其外观被修改时，此值在消息WM_MEASURE或WM_DRAWITEM的参数IParam指向的结构中、成员itemData里。</param>
        /// <returns>如果函数调用成功，返回值非零；如果函数调用失败，返回值为零。若想获得更多的错误信息，请调用GetLastError函数。</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool InsertMenu(IntPtr hMenu, uint uPosition, uint uFlags, uint uIDNewItem, string lpNewItem);
        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数从指定菜单删除一个菜单项或分离一个子菜单。如果菜单项打开一个下拉式菜单或子菜单，RemoveMenu不消毁该菜单或其句柄，允许菜单被重用。在调用此函数前，函数GetSubMenu应当取得下拉式菜单或子菜单的句柄。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>只要一个菜单被修改，无论它是否在显示窗口里，应用程序都必须调用函数DrawMenuBar。</para>
        /// </summary>
        /// <param name="hMenu">将被修改的菜单的句柄。</param>
        /// <param name="uPosition">指定将被删除的菜单项，其含义由参数uFlages决定。</param>
        /// <param name="uFlags">指定参数uPosition如何解释。此参数必须为下列之一值：MF_BYCOMMAND：表示uPositon给出菜单项的标识符。如果MF_BYCOMMAND和MF_BYPOSITION都没被指定，则MF_BYCOMMAND是缺省标志，常数 MF_BYCOMMAND＝0x0000（十进制为0）。Mu_BYPOSITION：表示uPositon给出菜单项相对于零的位置，常数 MF_BYPOSITION＝0x00004(十进制为1024)。</param>
        /// <returns>如果函数调用成功，返回非零值；如果函数调用失败，返回值是零。若想获得更多的错误信息，请调用GetLastError函数。</returns>
        [DllImport("user32")]
        public static extern int RemoveMenu(IntPtr hMenu, uint uPosition, uint uFlags);

        #endregion


        #region Scroll Bar Functions                                滚动条函数

        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数显示或隐藏所指定的滚动条。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>当处理滚动条消息时，不能调用这个函数隐藏滚动条。</para>
        /// </summary>
        /// <param name="hWnd">根据参数wBar值，处理滚动条控制或带有标准滚动条窗体。</param>
        /// <param name="wBar">指定滚动条是被显示还是隐藏。</param>
        /// <param name="bShow">指定滚动条是被显示还是隐藏。此参数为TRUE，滚动条将被显示，否则被隐藏。</param>
        /// <returns>如果函数运行成功，返回值为非零；如果函数运行失败，返回值为零。</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ShowScrollBar(IntPtr hWnd, int wBar, [MarshalAs(UnmanagedType.Bool)] bool bShow);
        /// <summary>
        /// <para>功能:</para>
        /// <para>检索有关指定滚动条信息。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>如果idObject是OBJID_CLIENT和指定的窗口的HWND是不是系统滚动条控制，系统发送SBM_GETSCROLLBARINFO信息的窗口滚动条来获取信息。</para>
        /// <para>这使得GetScrollBarInfo运作自定义控件模仿一个滚动条。如果窗口不处理SBM_GETSCROLLBARINFO消息，GetScrollBarInfo函数失败。</para>
        /// </summary>
        /// <param name="hwnd">窗口句柄。是一个滚动条控件的句柄。否则是一个具有WS_VSCROLL或WS_HSCROLL样式的窗口句柄。</param>
        /// <param name="idObject">指定滚动条对象。这个参数可以是以下值之一。 见OBJID_ 。说明OBJID_CLIENT hWnd参数是一个滚动条控件的句柄。OBJID_HSCROLL hWnd窗口水平滚动条。OBJID_VSCROLL hWnd窗口垂直滚动条。</param>
        /// <param name="psbi">指向一个SCROLLBARINFO结构，以获得的信息。在调用GetScrollBarInfo，设置cbSize成员为sizeof（SCROLLBARINFO）。</param>
        /// <returns>如果函数成功，返回值为非零。如果函数失败，返回值为零。为了获得更多的错误信息，调用GetLastError。</returns>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetScrollBarInfo(IntPtr hwnd, int idObject, ref NativeMethods.SCROLLBARINFO psbi);
        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数找到滚动条的参数，包括滚动条位置的最小值、最大值，页面大小，滚动按钮的位置等。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>Getscrolllnfo函数尽管WM_HSCROLL和WM_VSCROLL指出了滚动条位置消息，却仅提供了16位数据，而函数SetScrollnfo和GetScrollnfo则提供了32位的滚动条数据。</para>
        /// <para>因而，当应用程序在处理WM_HSCROLL或 WM_VSCROLL时，要获得32位滚动条位置的数据时，则要调用Getscrolllnfo函数。</para>
        /// <para>在WM_HSCROLL或WM_VSCROLL消息中SB_THUMBTRACK通告过程中，为了获得32位的滚动盒位置，需要调用GetScrolllnfo函数以得到结构SCROLLINFO成员fMask中的SCROLLINFO值。</para>
        /// <para>函数返回在结构SCROLLINFO成员nTrackPos中指出的滚动盒跟踪位置的值。这将允许当用户移动滚动盒时能得到其位置。</para>
        /// </summary>
        /// <param name="hwnd">滚动条控制或有标准滚动条的窗体句柄，由fnBar参数确定。</param>
        /// <param name="fnBar">指定待找回滚动条参数的类型，此参数可以为如下值，其值含义：见SB_</param>
        /// <param name="lpsi">指向SCROLLINFO结构。</param>
        /// <returns>如果函数找到任何一个值，那么返回值为非零；如果函数没有找到任何值，那么返回值为零；</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetScrollInfo(IntPtr hwnd, int fnBar, ref NativeMethods.SCROLLINFO lpsi);
        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数设置滚动条参数，包括滚动位置的最大值和最小值，页面大小，滚动按钮的位置。如被请求，函数也可以重画滚动条。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>SetScrolllnfo函数执行任务是检查SCROLLINFO结构中由成员nPage和nPos值的范围。</para>
        /// <para>成员nPage值必须从0到nMax- nMin+1，成员nPos必须是在nMin和nMax-nMax-max（nPage C1，0）之间的指定值。</para>
        /// <para>如果任何一个值超过了这个范围，函数将在指定范围内为它设置一个值。</para>
        /// </summary>
        /// <param name="hwnd">滚动条控件或带标准滚动条的窗体句柄，由fnBar参数决定。</param>
        /// <param name="fnBar">指定被设定参数的滚动条的类型。这个参数可以是下面值，含义如下：见SB_</param>
        /// <param name="lpsi">指向SCROLLINFO结构。在调用SetScrollInfo之前，设置SCROLLINFO结构中cbSize成员以标识结构大小，设置成员fMask以说明待设置的滚动条参数，并且在适当的成员中制定新的参数值。</param>
        /// <param name="fRedraw">指定滚动条是否重画以反映滚动条的变化。如果这个参数为TRUE，滚动条将被重画，否则不被重画。</param>
        /// <returns>返回值是滑块的当前位置。</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int SetScrollInfo(IntPtr hwnd, int fnBar, [In] ref NativeMethods.SCROLLINFO lpsi, bool fRedraw);
        /// <summary>
        /// <para>功能:该函数获取指定滚动条中滚动按钮的当前位置。当前位置是一个根据当前滚动范围而定的相对值。</para>
        /// <para>例如，如果滚动范围是0到100之间，滚动按钮在中间位置，则其当前位置为50。该函数提供了向后兼容性，新的应用程序应使用GetScrollInfo函数。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>函数GetScrollPos可以使应用程序使用32位滚动位置。尽管消息WM_HSCROLL和WM_VSCROLL指出了滚动条位置，但却被限制为16位，而函数SetScrollPos，SetScrollRange，GetScrollPos，和 GetscrollRange都支持32位的滚动条数据。</para>
        /// <para>在WM_HSCROLL或WM_VSCROLL消息中通告SB_JHUMBTRACK时，为了得到滚动条32位的位置，请调用GetScrolllnfo函数。</para>
        /// <para>在WM_HSCROLL或WM_VSCROLL消息中通告SB_THUMBTRACK时，为了得到32位的滚动条，则调用函数GetScrolllnfo。</para>
        /// </summary>
        /// <param name="hWnd">根据参数nBar值，处理滚动条控制或带有标准滚动条窗体。</param>
        /// <param name="nBar">指定滚动条将被检查。这个参数可以是下面值，含义如下：见SB_</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int GetScrollPos(IntPtr hWnd, int nBar);
        /// <summary>
        /// <para>功能:该函数设置所指定滚动条中的滚动按钮的位置，如果需要，可重绘滚动条以反映出滚动按钮的新位置。该函数提供了向后兼容性，新的应用程序应使用SetScrolllnfo函数。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>如果后续又调用了会重绘滚动条的函数，那么设置参数bRedraw为FALSE是非常有必要的。</para>
        /// <para>因为说明滚动条位置的消息WM_HSCROLL和 WM_VSCROLL只能为16位数据，那些只依赖于说明位置数据消息的应用程序在函数SetScrollPos的参数nMaxPos中有一个实际最大值65,535 。</para>
        /// <para>但是，因为函数SetScrolllnfo，SetScrollPos， SetScrollRange，GetScrolllnfo，GetScrollPos，和GetScrollRange都支持32位的滚动条位置数据，所以有一个解决16位WM_HSCROLL和WM_VSCROLL消息阻碍的途径，请参见函数GetScrolllnfo的有关技术说明。</para>
        /// </summary>
        /// <param name="hWnd">滚动条控件或带有标准滚动条窗体的句柄，由nBar参数值确定</param>
        /// <param name="nBar">指定滚动条将被设置。这个参数可以是下表值中的一个，含义如下：见SB_</param>
        /// <param name="nPos">指定滚动按钮的新位置。这个位置必须在滚动范围之内。若要了解更多有关滚动范围的信息，请参见SetScrollRange函数。</param>
        /// <param name="bRedraw">指定滚动条是否被重画以反映变化。如果这个参数为TRUE，滚动条将被重画；如果为FALSE则不被重画。</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int SetScrollPos(IntPtr hWnd, int nBar, int nPos, bool bRedraw);

        #endregion


        #region ComboBox Control Functions                          组合框控件函数

        /// <summary>
        /// <para>功能:</para>
        /// <para>Retrieves information about the specified combo box.</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>The CB_GETCOMBOBOXINFO message is equivalent to this function.</para>
        /// </summary>
        /// <param name="hwndCombo">A handle to the combo box.</param>
        /// <param name="pcbi">A pointer to a COMBOBOXINFO structure that receives the information. You must set COMBOBOXINFO.cbSize before calling this function.</param>
        /// <returns>f the function succeeds, the return value is nonzero.If the function fails, the return value is zero. To get extended error information, call GetLastError.</returns>
        [DllImport("user32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetComboBoxInfo(IntPtr hwndCombo, ref  NativeMethods.COMBOBOXINFO pcbi);

        #endregion
    }
}
