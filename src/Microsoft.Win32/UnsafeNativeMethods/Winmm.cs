using System;
using System.Runtime.InteropServices;

namespace Microsoft.Win32
{
    /// <summary>
    /// Winmm.dll
    /// </summary>
    public static partial class UnsafeNativeMethods
    {
        /// <summary>
        /// <para>功能:</para>
        /// <para>该函数返回的错误码可以用mciGetErrorString函数进行分析。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>无</para>
        /// </summary>
        /// <param name="fdwError">函数mciSendString返回的错误码</param>
        /// <param name="lpszErrorText">接收描述错误的字符串的缓冲区</param>
        /// <param name="cchErrorText">缓冲区的长度</param>
        /// <returns>如果函数运行成功，返回值为TRUE；如果函数运行失败，返回值为FALSE。</returns>
        [DllImport("winmm.dll", CharSet = CharSet.Auto)]
        public static extern bool mciGetErrorString(int fdwError, ref string lpszErrorText, uint cchErrorText);
        /// <summary>
        /// <para>功能:</para>
        /// <para>应用程序通过向MCI发送命令来控制媒体设备。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>无</para>
        /// </summary>
        /// <param name="lpszCommand">MCI命令字符串</param>
        /// <param name="lpszReturnString">存放反馈信息的缓冲区</param>
        /// <param name="cchReturn">缓冲区的长度</param>
        /// <param name="hwndCallback">回调窗口的句柄，一般为NULL</param>
        /// <returns>如果函数运行成功，返回值为零；如果函数运行失败，返回值为非零。</returns>
        [DllImport("winmm.dll", CharSet = CharSet.Auto)]
        public static extern int mciSendString(string lpszCommand, ref string lpszReturnString, uint cchReturn, IntPtr hwndCallback);


        /// <summary>
        /// The mmioAscend function ascends out of a chunk in a RIFF file descended into with the mmioDescend function or created with the mmioCreateChunk function.
        /// </summary>
        /// <param name="hMIO">File handle of an open RIFF file.</param>
        /// <param name="lpck">Pointer to an application-defined MMCKINFO structure previously filled by the mmioDescend or mmioCreateChunk function.</param>
        /// <param name="flags">Reserved; must be zero.</param>
        /// <returns>Returns MMSYSERR_NOERROR if successful or an error otherwise. Possible error values include the following.</returns>
        /// <summary>
        /// <para>Return code	Description</para>
        /// <para>MMIOERR_CANNOTSEEK</para>
        /// <para>There was an error while seeking to the end of the chunk.</para>
        /// <para>.</para>
        /// <para>MMIOERR_CANNOTWRITE</para>
        /// <para>The contents of the buffer could not be written to disk.</para>
        /// </summary>
        [DllImport("winmm.dll", CharSet = CharSet.Auto)]
        public static extern int mmioAscend(IntPtr hMIO, NativeMethods.MMCKINFO lpck, int flags);
        /// <summary>
        /// The mmioClose function closes a file that was opened by using the mmioOpen function.
        /// </summary>
        /// <param name="hMIO">File handle of the file to close.</param>
        /// <param name="flags">Flags for the close operation. The following value is defined.</param>
        /// <summary>
        /// <para>Value	 Meaning</para>
        /// <para>MMIO_FHOPEN	If the file was opened by passing a file handle whose type is not HMMIO, using this flag tells the mmioClose function to close the multimedia file handle, but not the standard file handle.</para>
        /// </summary>
        /// <returns>Returns zero if successful or an error otherwise. The error value can originate from the mmioFlush function or from the I/O procedure. Possible error values include the following.</returns>
        [DllImport("winmm.dll", CharSet = CharSet.Auto)]
        public static extern int mmioClose(IntPtr hMIO, int flags);
        /// <summary>
        /// The mmioDescend function descends into a chunk of a RIFF file that was opened by using the mmioOpen function. It can also search for a given chunk.
        /// </summary>
        /// <param name="hMIO">File handle of an open RIFF file.</param>
        /// <param name="lpck">Pointer to a buffer that receives an MMCKINFO structure.</param>
        /// <param name="lcpkParent">ointer to an optional application-defined MMCKINFO structure identifying the parent of the chunk being searched for. If this parameter is not NULL, mmioDescend assumes the MMCKINFO structure it refers to was filled when mmioDescend was called to descend into the parent chunk, and mmioDescend searches for a chunk within the parent chunk. Set this parameter to NULL if no parent chunk is being specified.</param>
        /// <param name="flags">Search flags. If no flags are specified, mmioDescend descends into the chunk beginning at the current file position. The following values are defined.</param>
        /// <summary>
        /// <para>Value	Meaning</para>
        /// <para>MMIO_FINDCHUNK	Searches for a chunk with the specified chunk identifier.</para>
        /// <para>MMIO_FINDLIST	Searches for a chunk with the chunk identifier &quot;LIST&quot; and with the specified form type.</para>
        /// <para>MMIO_FINDRIFF	Searches for a chunk with the chunk identifier &quot;RIFF&quot; and with the specified form type.</para>
        /// </summary>
        /// <returns>Returns MMSYSERR_NOERROR if successful or an error otherwise. Possible error values include the following.</returns>
        /// <summary>
        /// <para>Value	Description</para>
        /// <para>MMIOERR_CHUNKNOTFOUND	The end of the file (or the end of the parent chunk, if given) was reached before the desired chunk was found.</para>
        /// </summary>
        [DllImport("winmm.dll", CharSet = CharSet.Auto)]
        public static extern int mmioDescend(IntPtr hMIO, [MarshalAs(UnmanagedType.LPStruct)] NativeMethods.MMCKINFO lpck, [MarshalAs(UnmanagedType.LPStruct)] NativeMethods.MMCKINFO lcpkParent, int flags);
        /// <summary>
        /// The mmioOpen function opens a file for unbuffered or buffered I/O. The file can be a standard file, a memory file, or an element of a custom storage system. The handle returned by mmioOpen is not a standard file handle; do not use it with any file I/O functions other than multimedia file I/O functions.
        /// </summary>
        /// <param name="fileName">Pointer to a string containing the file name of the file to open. If no I/O procedure is specified to open the file, the file name determines how the file is opened, as follows:</param>
        /// <param name="not_used">Pointer to an MMIOINFO structure containing extra parameters used by mmioOpen. Unless you are opening a memory file, specifying the size of a buffer for buffered I/O, or specifying an uninstalled I/O procedure to open a file, this parameter should be NULL. If this parameter is not NULL, all unused members of the MMIOINFO structure it references must be set to zero, including the reserved members.</param>
        /// <param name="flags">Flags for the open operation. The MMIO_READ, MMIO_WRITE, and MMIO_READWRITE flags are mutually exclusive — only one should be specified. The MMIO_COMPAT, MMIO_EXCLUSIVE, MMIO_DENYWRITE, MMIO_DENYREAD, and MMIO_DENYNONE flags are file-sharing flags. The following values are defined.</param>
        /// <summary>
        /// <para>Value	Meaning</para>
        /// <para>MMIO_ALLOCBUF	Opens a file for buffered I/O. To allocate a buffer larger or smaller than the default buffer size (8K, defined as MMIO_DEFAULTBUFFER), set the cchBuffer member of the MMIOINFO structure to the desired buffer size. If cchBuffer is zero, the default buffer size is used. If you are providing your own I/O buffer, this flag should not be used.</para>
        /// <para>MMIO_COMPAT	Opens the file with compatibility mode, allowing any process on a given machine to open the file any number of times. If the file has been opened with any of the other sharing modes, mmioOpen fails.</para>
        /// <para>MMIO_CREATE	Creates a new file. If the file already exists, it is truncated to zero length. For memory files, this flag indicates the end of the file is initially at the start of the buffer.</para>
        /// <para>MMIO_DELETE	Deletes a file. If this flag is specified, szFilename should not be NULL. The return value is TRUE (cast to HMMIO) if the file was deleted successfully or FALSE otherwise. Do not call the mmioClose function for a file that has been deleted. If this flag is specified, all other flags that open files are ignored.</para>
        /// <para>MMIO_DENYNONE	Opens the file without denying other processes read or write access to the file. If the file has been opened in compatibility mode by any other process, mmioOpen fails.</para>
        /// <para>MMIO_DENYREAD	Opens the file and denies other processes read access to the file. If the file has been opened in compatibility mode or for read access by any other process, mmioOpen fails.</para>
        /// <para>MMIO_DENYWRITE	Opens the file and denies other processes write access to the file. If the file has been opened in compatibility mode or for write access by any other process, mmioOpen fails.</para>
        /// <para>MMIO_EXCLUSIVE	Opens the file and denies other processes read and write access to the file. If the file has been opened in any other mode for read or write access, even by the current process, mmioOpen fails.</para>
        /// <para>MMIO_EXIST	Determines whether the specified file exists and creates a fully qualified file name from the path specified in szFilename. The file name is placed back into szFilename. The return value is TRUE (cast to HMMIO) if the qualification was successful and the file exists or FALSE otherwise. The file is not opened, and the function does not return a valid multimedia file I/O file handle, so do not attempt to close the file.</para>
        /// <para>MMIO_GETTEMP	Creates a temporary file name, optionally using the parameters passed in szFilename. For example, you can specify &quot;C:F&quot; to create a temporary file residing on drive C, starting with letter &quot;F&quot;. The resulting file name is placed in the buffer pointed to by szFilename. The return value is MMSYSERR_NOERROR (cast to HMMIO) if the temporary file name was created successfully or MMIOERR_FILENOTFOUND otherwise. The file is not opened, and the function does not return a valid multimedia file I/O file handle, so do not attempt to close the file. This flag overrides all other flags.</para>
        /// <para>MMIO_PARSE	Creates a fully qualified file name from the path specified in szFilename. The file name is placed back into szFilename. The return value is TRUE (cast to HMMIO) if the qualification was successful or FALSE otherwise. The file is not opened, and the function does not return a valid multimedia file I/O file handle, so do not attempt to close the file. If this flag is specified, all flags that open files are ignored.</para>
        /// <para>MMIO_READ	Opens the file for reading only. This is the default if MMIO_WRITE and MMIO_READWRITE are not specified.</para>
        /// <para>MMIO_READWRITE	Opens the file for reading and writing.</para>
        /// <para>MMIO_WRITE	Opens the file for writing only.</para>
        /// </summary>
        /// <returns>Returns a handle of the opened file. If the file cannot be opened, the return value is NULL. If lpmmioinfo is not NULL, the wErrorRet member of the MMIOINFO structure will contain one of the following error values.</returns>
        /// <summary>
        /// <para>Value	Description</para>
        /// <para>MMIOERR_ACCESSDENIED	The file is protected and cannot be opened.</para>
        /// <para>MMIOERR_INVALIDFILE	Another failure condition occurred. This is the default error for an open-file failure.</para>
        /// <para>MMIOERR_NETWORKERROR	The network is not responding to the request to open a remote file.</para>
        /// <para>MMIOERR_PATHNOTFOUND	The directory specification is incorrect.</para>
        /// <para>MMIOERR_SHARINGVIOLATION	The file is being used by another application and is unavailable.</para>
        /// <para>MMIOERR_TOOMANYOPENFILES	The number of files simultaneously open is at a maximum level. The system has run out of available file handles.</para>
        /// </summary>
        [DllImport("winmm.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr mmioOpen(string fileName, IntPtr not_used, int flags);
        /// <summary>
        /// The mmioRead function reads a specified number of bytes from a file opened by using the mmioOpen function.
        /// </summary>
        /// <param name="hMIO">File handle of the file to be read.</param>
        /// <param name="wf">Pointer to a buffer to contain the data read from the file.</param>
        /// <param name="cch">Number of bytes to read from the file.</param>
        /// <returns>Returns the number of bytes actually read. If the end of the file has been reached and no more bytes can be read, the return value is 0. If there is an error reading from the file, the return value is - 1.</returns>
        [DllImport("winmm.dll", CharSet = CharSet.Auto)]
        public static extern int mmioRead(IntPtr hMIO, [MarshalAs(UnmanagedType.LPArray)] byte[] wf, int cch);


        /// <summary>
        /// <para>功能:</para>
        /// <para>播放音频(文件名,资源名,系统事件声音)</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>无</para>
        /// <para>.</para>
        /// <para>下列标志可被设置在参数fdwSound里:</para>
        /// <para>SND_SYNC：同步播放声音，在播放完后PlaySound函数才返回。</para>
        /// <para>SND_ASYNC：用异步方式播放声音，PlaySound函数在开始播放后立即返回。</para>
        /// <para>SND_NODEFAULT：不播放缺省声音，若无此标志，则PlaySound在没找到声音时会播放缺省声音。</para>
        /// <para>SND_MEMORY：播放载入到内存中的声音，此时pszSound是指向声音数据的指针。</para>
        /// <para>SND_LOOP：重复播放声音，必须与SND_ASYNC标志一块使用。</para>
        /// <para>SND_NOSTOP：PlaySound不打断原来的声音播出并立即返回FALSE。</para>
        /// <para>SND_PURGE：停止所有与调用任务有关的声音。若参数pszSound为NULL，就停止所有的声音，否则，停止pszSound指定的声音。</para>
        /// <para>SND_NOWAIT：如果驱动程序正忙则函数就不播放声音并立即返回。</para>
        /// <para>SND_ALIAS：pszSound参数指定了注册表或WIN.INI中的系统事件的别名。</para>
        /// <para>SND_ALIAS_ID：pszSound参数指定了预定义的声音标识符。</para>
        /// <para>SND_FILENAME：pszSound参数指定了WAVE文件名。</para>
        /// <para>SND_RESOURCE：pszSound参数是WAVE资源的标识符，这时要用到hmod参数。</para>
        /// </summary>
        /// <param name="soundName">指定了要播放声音的字符串，该参数可以是WAVE文件的名字，或是WAV资源的名字，或是内存中声音数据的指针，或是在系统注册表WIN.INI中定义的系统事件声音。如果该参数为NULL则停止正在播放的声音。</param>
        /// <param name="hmod">应用程序的实例句柄，除非pszSound的指向一个资源标识符（即fdwSound被定义为SND_RESOURCE），否则必须设置为NULL。</param>
        /// <param name="soundFlags">标志的组合。</param>
        /// <returns>若成功则函数返回TRUE，否则返回FALSE。</returns>
        [DllImport("winmm.dll", CharSet = CharSet.Auto)]
        public static extern bool PlaySound([MarshalAs(UnmanagedType.LPWStr)] string soundName, IntPtr hmod, int soundFlags);
        /// <summary>
        /// <para>功能:</para>
        /// <para>播放音频(文件名,资源名,系统事件声音)</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>无</para>
        /// <para>.</para>
        /// <para>下列标志可被设置在参数fdwSound里:</para>
        /// <para>SND_SYNC：同步播放声音，在播放完后PlaySound函数才返回。</para>
        /// <para>SND_ASYNC：用异步方式播放声音，PlaySound函数在开始播放后立即返回。</para>
        /// <para>SND_NODEFAULT：不播放缺省声音，若无此标志，则PlaySound在没找到声音时会播放缺省声音。</para>
        /// <para>SND_MEMORY：播放载入到内存中的声音，此时pszSound是指向声音数据的指针。</para>
        /// <para>SND_LOOP：重复播放声音，必须与SND_ASYNC标志一块使用。</para>
        /// <para>SND_NOSTOP：PlaySound不打断原来的声音播出并立即返回FALSE。</para>
        /// <para>SND_PURGE：停止所有与调用任务有关的声音。若参数pszSound为NULL，就停止所有的声音，否则，停止pszSound指定的声音。</para>
        /// <para>SND_NOWAIT：如果驱动程序正忙则函数就不播放声音并立即返回。</para>
        /// <para>SND_ALIAS：pszSound参数指定了注册表或WIN.INI中的系统事件的别名。</para>
        /// <para>SND_ALIAS_ID：pszSound参数指定了预定义的声音标识符。</para>
        /// <para>SND_FILENAME：pszSound参数指定了WAVE文件名。</para>
        /// <para>SND_RESOURCE：pszSound参数是WAVE资源的标识符，这时要用到hmod参数。</para>
        /// </summary>
        /// <param name="soundName">指定了要播放声音的字符串，该参数可以是WAVE文件的名字，或是WAV资源的名字，或是内存中声音数据的指针，或是在系统注册表WIN.INI中定义的系统事件声音。如果该参数为NULL则停止正在播放的声音。</param>
        /// <param name="hmod">应用程序的实例句柄，除非pszSound的指向一个资源标识符（即fdwSound被定义为SND_RESOURCE），否则必须设置为NULL。</param>
        /// <param name="soundFlags">标志的组合。</param>
        /// <returns>若成功则函数返回TRUE，否则返回FALSE。</returns>
        [DllImport("winmm.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool PlaySound(byte[] soundName, IntPtr hmod, int soundFlags);
        /// <summary>
        /// <para>功能:</para>
        /// <para>播放音频(内存中声音数据的指针)</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>无</para>
        /// <para>.</para>
        /// <para>下列标志可被设置在参数fdwSound里:</para>
        /// <para>SND_SYNC：同步播放声音，在播放完后PlaySound函数才返回。</para>
        /// <para>SND_ASYNC：用异步方式播放声音，PlaySound函数在开始播放后立即返回。</para>
        /// <para>SND_NODEFAULT：不播放缺省声音，若无此标志，则PlaySound在没找到声音时会播放缺省声音。</para>
        /// <para>SND_MEMORY：播放载入到内存中的声音，此时pszSound是指向声音数据的指针。</para>
        /// <para>SND_LOOP：重复播放声音，必须与SND_ASYNC标志一块使用。</para>
        /// <para>SND_NOSTOP：PlaySound不打断原来的声音播出并立即返回FALSE。</para>
        /// <para>SND_PURGE：停止所有与调用任务有关的声音。若参数pszSound为NULL，就停止所有的声音，否则，停止pszSound指定的声音。</para>
        /// <para>SND_NOWAIT：如果驱动程序正忙则函数就不播放声音并立即返回。</para>
        /// <para>SND_ALIAS：pszSound参数指定了注册表或WIN.INI中的系统事件的别名。</para>
        /// <para>SND_ALIAS_ID：pszSound参数指定了预定义的声音标识符。</para>
        /// <para>SND_FILENAME：pszSound参数指定了WAVE文件名。</para>
        /// <para>SND_RESOURCE：pszSound参数是WAVE资源的标识符，这时要用到hmod参数。</para>
        /// </summary>
        /// <param name="pszSound">指定了要播放声音的字符串，该参数可以是WAVE文件的名字，或是WAV资源的名字，或是内存中声音数据的指针，或是在系统注册表WIN.INI中定义的系统事件声音。如果该参数为NULL则停止正在播放的声音。</param>
        /// <param name="hMod">应用程序的实例句柄，除非pszSound的指向一个资源标识符（即fdwSound被定义为SND_RESOURCE），否则必须设置为NULL。</param>
        /// <param name="fdwSound">标志的组合。</param>
        /// <returns>若成功则函数返回TRUE，否则返回FALSE。</returns>
        [DllImport("winmm.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool PlaySound(IntPtr pszSound, IntPtr hMod, uint fdwSound);
    }
}
