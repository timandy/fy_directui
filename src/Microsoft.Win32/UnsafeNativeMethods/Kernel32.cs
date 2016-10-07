using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.Win32
{
    /// <summary>
    /// Kernel32.dll
    /// </summary>
    public static partial class UnsafeNativeMethods
    {
        #region Time Functions                                      时间函数

        /// <summary>
        /// <para>功能:</para>
        /// <para>Retrieves the number of milliseconds that have elapsed since the system was started, up to 49.7 days.</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>The resolution of the GetTickCount function is limited to the resolution of the system timer, which is typically in the range of 10 milliseconds to 16 milliseconds. The resolution of the GetTickCount function is not affected by adjustments made by the GetSystemTimeAdjustment function.</para>
        /// <para>The elapsed time is stored as a DWORD value. Therefore, the time will wrap around to zero if the system is run continuously for 49.7 days. To avoid this problem, use the GetTickCount64 function. Otherwise, check for an overflow condition when comparing times.</para>
        /// <para>If you need a higher resolution timer, use a multimedia timer or a high-resolution timer.</para>
        /// <para>To obtain the time elapsed since the computer was started, retrieve the System Up Time counter in the performance data in the registry key HKEY_PERFORMANCE_DATA. The value returned is an 8-byte value. For more information, see Performance Counters.</para>
        /// <para>To obtain the time the system has spent in the working state since it was started, use the QueryUnbiasedInterruptTime function.</para>
        /// <para>Note  The QueryUnbiasedInterruptTime function produces different results on debug (&quot;checked&quot;) builds of Windows, because the interrupt-time count and tick count are advanced by approximately 49 days. This helps to identify bugs that might not occur until the system has been running for a long time. The checked build is available to MSDN subscribers through the Microsoft Developer Network (MSDN) Web site.</para>
        /// </summary>
        /// <returns>The return value is the number of milliseconds that have elapsed since the system was started.</returns>
        [DllImport("Kernel32.dll")]
        public static extern int GetTickCount();

        /// <summary>
        /// <para>功能:</para>
        /// <para>Retrieves the frequency of the performance counter. The frequency of the performance counter is fixed at system boot and is consistent across all processors. Therefore, the frequency need only be queried upon application initialization, and the result can be cached.</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>For more info about this function and its usage, see Acquiring high-resolution time stamps.</para>
        /// </summary>
        /// <param name="lpFrequency">A pointer to a variable that receives the current performance-counter frequency, in counts per second. If the installed hardware doesn't support a high-resolution performance counter, this parameter can be zero (this will not occur on systems that run Windows XP or later).</param>
        /// <returns>
        /// <para>If the installed hardware supports a high-resolution performance counter, the return value is nonzero.</para>
        /// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError. On systems that run Windows XP or later, the function will always succeed and will thus never return zero.</para>
        /// </returns>
        [DllImport("Kernel32.dll")]
        public static extern bool QueryPerformanceFrequency(out long lpFrequency);

        /// <summary>
        /// <para>功能:</para>
        /// <para>Retrieves the current value of the performance counter, which is a high resolution (&lt;1us) time stamp that can be used for time-interval measurements.</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>For more info about this function and its usage, see Acquiring high-resolution time stamps.</para>
        /// </summary>
        /// <param name="lpPerformanceCount">A pointer to a variable that receives the current performance-counter value, in counts.</param>
        /// <returns>
        /// <para>If the function succeeds, the return value is nonzero.</para>
        /// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError. On systems that run Windows XP or later, the function will always succeed and will thus never return zero.</para>
        /// </returns>
        [DllImport("Kernel32.dll")]
        public static extern bool QueryPerformanceCounter(out long lpPerformanceCount);

        #endregion


        #region Registry Functions                                  注册表函数

        /// <summary>
        /// Retrieves a string from the specified section in an initialization file.Note  This function is provided only for compatibility with 16-bit Windows-based applications. Applications should store initialization information in the registry.
        /// </summary>
        /// <param name="lpAppName">The name of the section containing the key name. If this parameter is NULL, the GetPrivateProfileString function copies all section names in the file to the supplied buffer.</param>
        /// <param name="lpKeyName">The name of the key whose associated string is to be retrieved. If this parameter is NULL, all key names in the section specified by the lpAppName parameter are copied to the buffer specified by the lpReturnedString parameter.</param>
        /// <param name="lpDefault">A default string. If the lpKeyName key cannot be found in the initialization file, GetPrivateProfileString copies the default string to the lpReturnedString buffer. If this parameter is NULL, the default is an empty string, "".Avoid specifying a default string with trailing blank characters. The function inserts a null character in the lpReturnedString buffer to strip any trailing blanks.</param>
        /// <param name="lpReturnedString">A pointer to the buffer that receives the retrieved string.</param>
        /// <param name="nSize">The size of the buffer pointed to by the lpReturnedString parameter, in characters.</param>
        /// <param name="lpFileName">The name of the initialization file. If this parameter does not contain a full path to the file, the system searches for the file in the Windows directory.</param>
        /// <returns></returns>
        /// <summary>
        /// <para>The return value is the number of characters copied to the buffer, not including the terminating null character.</para>
        /// <para>If neither lpAppName nor lpKeyName is NULL and the supplied destination buffer is too small to hold the requested string, the string is truncated and followed by a null character, and the return value is equal to nSize minus one.</para>
        /// <para>If either lpAppName or lpKeyName is NULL and the supplied destination buffer is too small to hold all the strings, the last string is truncated and followed by two null characters. In this case, the return value is equal to nSize minus two.</para>
        /// <para>In the event the initialization file specified by lpFileName is not found, or contains invalid values, this function will set errorno with a value of &apos;0x2&apos; (File Not Found). To retrieve extended error information, call GetLastError.</para>
        /// </summary>
        [DllImport("kernel32.dll")]
        public static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, byte[] lpReturnedString, int nSize, string lpFileName);
        /// <summary>
        /// Retrieves a string from the specified section in an initialization file.Note  This function is provided only for compatibility with 16-bit Windows-based applications. Applications should store initialization information in the registry.
        /// </summary>
        /// <param name="lpAppName">The name of the section containing the key name. If this parameter is NULL, the GetPrivateProfileString function copies all section names in the file to the supplied buffer.</param>
        /// <param name="lpKeyName">The name of the key whose associated string is to be retrieved. If this parameter is NULL, all key names in the section specified by the lpAppName parameter are copied to the buffer specified by the lpReturnedString parameter.</param>
        /// <param name="lpDefault">A default string. If the lpKeyName key cannot be found in the initialization file, GetPrivateProfileString copies the default string to the lpReturnedString buffer. If this parameter is NULL, the default is an empty string, "".Avoid specifying a default string with trailing blank characters. The function inserts a null character in the lpReturnedString buffer to strip any trailing blanks.</param>
        /// <param name="lpReturnedString">A pointer to the buffer that receives the retrieved string.</param>
        /// <param name="nSize">The size of the buffer pointed to by the lpReturnedString parameter, in characters.</param>
        /// <param name="lpFileName">The name of the initialization file. If this parameter does not contain a full path to the file, the system searches for the file in the Windows directory.</param>
        /// <returns></returns>
        /// <summary>
        /// <para>The return value is the number of characters copied to the buffer, not including the terminating null character.</para>
        /// <para>If neither lpAppName nor lpKeyName is NULL and the supplied destination buffer is too small to hold the requested string, the string is truncated and followed by a null character, and the return value is equal to nSize minus one.</para>
        /// <para>If either lpAppName or lpKeyName is NULL and the supplied destination buffer is too small to hold all the strings, the last string is truncated and followed by two null characters. In this case, the return value is equal to nSize minus two.</para>
        /// <para>In the event the initialization file specified by lpFileName is not found, or contains invalid values, this function will set errorno with a value of &apos;0x2&apos; (File Not Found). To retrieve extended error information, call GetLastError.</para>
        /// </summary>
        [DllImport("kernel32.dll")]
        public static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);
        /// <summary>
        /// Copies a string into the specified section of an initialization file.This function is provided only for compatibility with 16-bit versions of Windows. Applications should store initialization information in the registry.
        /// </summary>
        /// <param name="lpAppName">[Section]The name of the section to which the string will be copied. If the section does not exist, it is created. The name of the section is case-independent; the string can be any combination of uppercase and lowercase letters.</param>
        /// <param name="lpKeyName">[Key]The name of the key to be associated with a string. If the key does not exist in the specified section, it is created. If this parameter is NULL, the entire section, including all entries within the section, is deleted.</param>
        /// <param name="lpString">[Value]A null-terminated string to be written to the file. If this parameter is NULL, the key pointed to by the lpKeyName parameter is deleted.</param>
        /// <param name="lpFileName">[文件绝对路径]The name of the initialization file.If the file was created using Unicode characters, the function writes Unicode characters to the file. Otherwise, the function writes ANSI characters.</param>
        /// <returns>If the function successfully copies the string to the initialization file, the return value is nonzero.If the function fails, or if it flushes the cached version of the most recently accessed initialization file, the return value is zero. To get extended error information, call GetLastError.</returns>
        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);

        #endregion


        #region Error Handling Functions                            错误处理函数

        /// <summary>
        /// <para>.Net平台不要调用此API，应该调用Marshal.GetLastWin32Error()但要在DllImport时设置 SetLastError = true。</para>
        /// <para>原因:</para>
        /// <para>在.Net 平台下通过PInvoke调用API后,最后错误代码在调用GetLastError()前可能被重写。所以GetLastError()获取到的结果可能为错误的。</para>
        /// <para>如果在Pinvoke的DllImport时设置SetLastError = true(默认为false)在调用完API后会立即为GetLastWin32Error()保存错误代码。此后即便最后错误代码被重写通过调用Marshal.GetLastWin32Error()仍能获取到正确的结果。</para>
        /// <para>步骤:</para>
        /// <para>1,DllImport时需要设置SetLastError = true</para>
        /// <para>2,调用完API后调用Marshal.GetLastWin32Error()而不是GetLastError()</para>
        /// <para>.</para>
        /// <para>功能:</para>
        /// <para>该函数返回调用线程最近的错误代码值，错误代码以单线程为基础来维护的，多线程不重写各自的错误代码值。</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>通过调用线程执行的函数调用设置此值 SetLastError函数。你应该调用 GetLastError函数马上功能时，函数的返回值表示，这样的调用将返回有用的数据。这是因为一些函数调用 SetLastError一个零，当他们取得成功，歼灭由最近失败的功能设置错误代码。</para>
        /// <para>要获得系统错误代码的错误字符串，可以使用 FORMATMESSAGE功能。有关错误代码由操作系统提供的完整列表，请参见 系统错误代码。</para>
        /// <para>由函数返回的错误代码是不是Windows API规范的一部分，可以通过操作系统或设备驱动程序而异。出于这个原因，我们无法提供的，可以由每个函数返回错误代码的完整列表。也有许多功能，其文档不包括甚至局部的，可以返回的错误代码列表。</para>
        /// <para>错误代码是32位值（位31是最显著位）。位29是保留给应用程序定义的错误代码，没有系统错误代码有此位设置。如果你是为你的应用程序定义的错误代码，设置该位为1。这表明，错误代码已被应用程序定义，并确保您的错误代码不能用系统定义的任何错误代码发生冲突。</para>
        /// <para>若要将系统错误成一个HRESULT值，使用 HRESULT_FROM_WIN32宏。</para>
        /// </summary>
        /// <returns>
        /// <para>The return value is the calling thread&apos;s last-error code.</para>
        /// <para>The Return Value section of the documentation for each function that sets the last-error code notes the conditions under which the function sets the last-error code.</para>
        /// <para>Most functions that set the thread&apos;s last-error code set it when they fail.</para>
        /// <para>However, some functions also set the last-error code when they succeed.</para>
        /// <para>If the function is not documented to set the last-error code, the value returned by this function is simply the most recent last-error code to have been set;</para>
        /// <para>some functions set the last-error code to 0 on success and others do not.</para>
        /// </returns>
        [DllImport("kernel32.dll")]
        public static extern int GetLastError();

        /// <summary>
        /// <para>功能:</para>
        /// <para>Formats a message string.</para>
        /// <para>The function requires a message definition as input.</para>
        /// <para>The message definition can come from a buffer passed into the function.</para>
        /// <para>It can come from a message table resource in an already-loaded module.</para>
        /// <para>Or the caller can ask the function to search the system&apos;s message table resource(s) for the message definition.</para>
        /// <para>The function finds the message definition in a message table resource based on a message identifier and a language identifier.</para>
        /// <para>The function copies the formatted message text to an output buffer, processing any embedded insert sequences if requested.</para>
        /// <para>.</para>
        /// <para>备注:</para>
        /// <para>Within the message text, several escape sequences are supported for dynamically formatting the message. These escape sequences and their meanings are shown in the following tables. All escape sequences start with the percent character (%).</para>
        /// <para>Escape sequence	Meaning</para>
        /// <para>%0	Terminates a message text line without a trailing new line character. This escape sequence can be used to build up long lines or to terminate the message itself without a trailing new line character. It is useful for prompt messages.</para>
        /// <para>%n!format string!</para>
        /// <para>Identifies an insert. The value of n can be in the range from 1 through 99. The format string (which must be surrounded by exclamation marks) is optional and defaults to !s! if not specified. For more information, see Format Specification Fields.</para>
        /// <para>The format string can include a width and precision specifier for strings and a width specifier for integers. Use an asterisk (*) to specify the width and precision. For example, %1!*.*s! or %1!*u!.</para>
        /// <para>If you do not use the width and precision specifiers, the insert numbers correspond directly to the input arguments. For example, if the source string is &quot;%1 %2 %1&quot; and the input arguments are &quot;Bill&quot; and &quot;Bob&quot;, the formatted output string is &quot;Bill Bob Bill&quot;.</para>
        /// <para>However, if you use a width and precision specifier, the insert numbers do not correspond directly to the input arguments. For example, the insert numbers for the previous example could change to &quot;%1!*.*s! %4 %5!*s!&quot;.</para>
        /// <para>The insert numbers depend on whether you use an arguments array (FORMAT_MESSAGE_ARGUMENT_ARRAY) or a va_list. For an arguments array, the next insert number is n+2 if the previous format string contained one asterisk and is n+3 if two asterisks were specified. For a va_list, the next insert number is n+1 if the previous format string contained one asterisk and is n+2 if two asterisks were specified.</para>
        /// <para>If you want to repeat &quot;Bill&quot;, as in the previous example, the arguments must include &quot;Bill&quot; twice. For example, if the source string is &quot;%1!*.*s! %4 %5!*s!&quot;, the arguments could be, 4, 2, Bill, Bob, 6, Bill (if using the FORMAT_MESSAGE_ARGUMENT_ARRAY flag). The formatted string would then be &quot;  Bi Bob   Bill&quot;.</para>
        /// <para>Repeating insert numbers when the source string contains width and precision specifiers may not yield the intended results. If you replaced %5 with %1, the function would try to print a string at address 6 (likely resulting in an access violation).</para>
        /// <para>Floating-point format specifiers—e, E, f, and g—are not supported. The workaround is to use the StringCchPrintf function to format the floating-point number into a temporary buffer, then use that buffer as the insert string.</para>
        /// <para>Inserts that use the I64 prefix are treated as two 32-bit arguments. They must be used before subsequent arguments are used. Note that it may be easier for you to use StringCchPrintf instead of this prefix.</para>
        /// <para>.</para>
        /// <para>Any other nondigit character following a percent character is formatted in the output message without the percent character. Following are some examples.</para>
        /// <para>Format string	Resulting output</para>
        /// <para>%%	A single percent sign.</para>
        /// <para>%space	A single space. This format string can be used to ensure the appropriate number of trailing spaces in a message text line.</para>
        /// <para>%.	A single period. This format string can be used to include a single period at the beginning of a line without terminating the message text definition.</para>
        /// <para>%!	A single exclamation point. This format string can be used to include an exclamation point immediately after an insert without its being mistaken for the beginning of a format string.</para>
        /// <para>%n	A hard line break when the format string occurs at the end of a line. This format string is useful when FormatMessage is supplying regular line breaks so the message fits in a certain width.</para>
        /// <para>%r	A hard carriage return without a trailing newline character.</para>
        /// <para>%t	A single tab.</para>
        /// <para>.</para>
        /// <para>Security Remarks</para>
        /// <para>If this function is called without FORMAT_MESSAGE_IGNORE_INSERTS, the Arguments parameter must contain enough parameters to satisfy all insertion sequences in the message string, and they must be of the correct type. Therefore, do not use untrusted or unknown message strings with inserts enabled because they can contain more insertion sequences than Arguments provides, or those that may be of the wrong type. In particular, it is unsafe to take an arbitrary system error code returned from an API and use FORMAT_MESSAGE_FROM_SYSTEM without FORMAT_MESSAGE_IGNORE_INSERTS.</para>
        /// <para>.</para>
        /// </summary>
        /// <param name="dwFlags">The formatting options, and how to interpret the lpSource parameter. The low-order byte of dwFlags specifies how the function handles line breaks in the output buffer. The low-order byte can also specify the maximum width of a formatted output line.</param>
        /// <param name="lpSource">The location of the message definition. The type of this parameter depends upon the settings in the dwFlags parameter.</param>
        /// <param name="dwMessageId">The message identifier for the requested message. This parameter is ignored if dwFlags includes FORMAT_MESSAGE_FROM_STRING.</param>
        /// <param name="dwLanguageId">The language identifier for the requested message. This parameter is ignored if dwFlags includes FORMAT_MESSAGE_FROM_STRING.</param>
        /// <param name="lpBuffer">A pointer to a buffer that receives the null-terminated string that specifies the formatted message. If dwFlags includes FORMAT_MESSAGE_ALLOCATE_BUFFER, the function allocates a buffer using the LocalAlloc function, and places the pointer to the buffer at the address specified in lpBuffer.This buffer cannot be larger than 64K bytes.</param>
        /// <param name="nSize">If the FORMAT_MESSAGE_ALLOCATE_BUFFER flag is not set, this parameter specifies the size of the output buffer, in TCHARs. If FORMAT_MESSAGE_ALLOCATE_BUFFER is set, this parameter specifies the minimum number of TCHARs to allocate for an output buffer.The output buffer cannot be larger than 64K bytes.</param>
        /// <param name="Arguments">An array of values that are used as insert values in the formatted message. A %1 in the format string indicates the first value in the Arguments array; a %2 indicates the second argument; and so on.The interpretation of each value depends on the formatting information associated with the insert in the message definition. The default is to treat each value as a pointer to a null-terminated string.By default, the Arguments parameter is of type va_list*, which is a language- and implementation-specific data type for describing a variable number of arguments. The state of the va_list argument is undefined upon return from the function. To use the va_list again, destroy the variable argument list pointer using va_end and reinitialize it with va_start.If you do not have a pointer of type va_list*, then specify the FORMAT_MESSAGE_ARGUMENT_ARRAY flag and pass a pointer to an array of DWORD_PTR values; those values are input to the message formatted as the insert values. Each insert must have a corresponding element in the array.</param>
        /// <returns>If the function succeeds, the return value is the number of TCHARs stored in the output buffer, excluding the terminating null character.If the function fails, the return value is zero. To get extended error information, call GetLastError.</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int FormatMessage(int dwFlags, IntPtr lpSource, int dwMessageId, int dwLanguageId, StringBuilder lpBuffer, int nSize, IntPtr Arguments);

        #endregion


        #region File Management Functions                           文件管理函数

        /// <summary>
        /// <para>功能:</para>
        /// <para>Creates an input/output (I/O) completion port and associates it with a specified file handle, or creates an I/O completion port that is not yet associated with a file handle, allowing association at a later time.</para>
        /// <para>Associating an instance of an opened file handle with an I/O completion port allows a process to receive notification of the completion of asynchronous I/O operations involving that file handle.</para>
        /// <para>Note</para>
        /// <para>The term file handle as used here refers to a system abstraction that represents an overlapped I/O endpoint, not only a file on disk. Any system objects that support overlapped I/O—such as network endpoints, TCP sockets, named pipes, and mail slots—can be used as file handles. For additional information, see the Remarks section.</para>
        /// <para>备注:</para>
        /// <para>The I/O system can be instructed to send I/O completion notification packets to I/O completion ports, where they are queued. The CreateIoCompletionPort function provides this functionality.</para>
        /// <para>An I/O completion port and its handle are associated with the process that created it and is not sharable between processes. However, a single handle is sharable between threads in the same process.</para>
        /// <para>CreateIoCompletionPort can be used in three distinct modes:</para>
        /// <para>Create only an I/O completion port without associating it with a file handle.</para>
        /// <para>Associate an existing I/O completion port with a file handle.</para>
        /// <para>Perform both creation and association in a single call.</para>
        /// <para>To create an I/O completion port without associating it, set the FileHandle parameter to INVALID_HANDLE_VALUE, the ExistingCompletionPort parameter to NULL, and the CompletionKey parameter to zero (which is ignored in this case). Set the NumberOfConcurrentThreads parameter to the desired concurrency value for the new I/O completion port, or zero for the default (the number of processors in the system).</para>
        /// <para>The handle passed in the FileHandle parameter can be any handle that supports overlapped I/O. Most commonly, this is a handle opened by the CreateFile function using the FILE_FLAG_OVERLAPPED flag (for example, files, mail slots, and pipes). Objects created by other functions such as socket can also be associated with an I/O completion port. For an example using sockets, see AcceptEx. A handle can be associated with only one I/O completion port, and after the association is made, the handle remains associated with that I/O completion port until it is closed.</para>
        /// <para>For more information on I/O completion port theory, usage, and associated functions, see I/O Completion Ports.</para>
        /// <para>Multiple file handles can be associated with a single I/O completion port by calling CreateIoCompletionPort multiple times with the same I/O completion port handle in the ExistingCompletionPort parameter and a different file handle in the FileHandle parameter each time.</para>
        /// <para>Use the CompletionKey parameter to help your application track which I/O operations have completed. This value is not used by CreateIoCompletionPort for functional control; rather, it is attached to the file handle specified in the FileHandle parameter at the time of association with an I/O completion port. This completion key should be unique for each file handle, and it accompanies the file handle throughout the internal completion queuing process. It is returned in the GetQueuedCompletionStatus function call when a completion packet arrives. The CompletionKey parameter is also used by the PostQueuedCompletionStatus function to queue your own special-purpose completion packets.</para>
        /// <para>After an instance of an open handle is associated with an I/O completion port, it cannot be used in the ReadFileEx or WriteFileEx function because these functions have their own asynchronous I/O mechanisms.</para>
        /// <para>It is best not to share a file handle associated with an I/O completion port by using either handle inheritance or a call to the DuplicateHandle function. Operations performed with such duplicate handles generate completion notifications. Careful consideration is advised.</para>
        /// <para>The I/O completion port handle and every file handle associated with that particular I/O completion port are known as references to the I/O completion port. The I/O completion port is released when there are no more references to it. Therefore, all of these handles must be properly closed to release the I/O completion port and its associated system resources. After these conditions are satisfied, close the I/O completion port handle by calling the CloseHandle function.</para>
        /// <para>In Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
        /// </summary>
        /// <param name="FileHandle">An open file handle or INVALID_HANDLE_VALUE.The handle must be to an object that supports overlapped I/O.If a handle is provided, it has to have been opened for overlapped I/O completion. For example, you must specify the FILE_FLAG_OVERLAPPED flag when using the CreateFile function to obtain the handle.If INVALID_HANDLE_VALUE is specified, the function creates an I/O completion port without associating it with a file handle. In this case, the ExistingCompletionPort parameter must be NULL and the CompletionKey parameter is ignored.</param>
        /// <param name="ExistingCompletionPort">A handle to an existing I/O completion port or NULL.If this parameter specifies an existing I/O completion port, the function associates it with the handle specified by the FileHandle parameter. The function returns the handle of the existing I/O completion port if successful; it does not create a new I/O completion port.If this parameter is NULL, the function creates a new I/O completion port and, if the FileHandle parameter is valid, associates it with the new I/O completion port. Otherwise no file handle association occurs. The function returns the handle to the new I/O completion port if successful.</param>
        /// <param name="CompletionKey">The per-handle user-defined completion key that is included in every I/O completion packet for the specified file handle. For more information, see the Remarks section.</param>
        /// <param name="NumberOfConcurrentThreads">The maximum number of threads that the operating system can allow to concurrently process I/O completion packets for the I/O completion port. This parameter is ignored if the ExistingCompletionPort parameter is not NULL.If this parameter is zero, the system allows as many concurrently running threads as there are processors in the system.</param>
        /// <returns>If the function succeeds, the return value is the handle to an I/O completion port:If the ExistingCompletionPort parameter was NULL, the return value is a new handle.If the ExistingCompletionPort parameter was a valid I/O completion port handle, the return value is that same handle.If the FileHandle parameter was a valid handle, that file handle is now associated with the returned I/O completion port.If the function fails, the return value is NULL. To get extended error information, call the GetLastError function.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr CreateIoCompletionPort(IntPtr FileHandle, IntPtr ExistingCompletionPort, IntPtr CompletionKey, int NumberOfConcurrentThreads);

        /// <summary>
        /// <para>功能:</para>
        /// <para>Attempts to dequeue an I/O completion packet from the specified I/O completion port. If there is no completion packet queued, the function waits for a pending I/O operation associated with the completion port to complete.</para>
        /// <para>To dequeue multiple I/O completion packets at once, use the GetQueuedCompletionStatusEx function.</para>
        /// <para>备注:</para>
        /// <para>This function associates a thread with the specified completion port. A thread can be associated with at most one completion port.</para>
        /// <para>If a call to GetQueuedCompletionStatus fails because the completion port handle associated with it is closed while the call is outstanding, the function returns FALSE, *lpOverlapped will be NULL, and GetLastError will return ERROR_ABANDONED_WAIT_0.</para>
        /// <para>Windows Server 2003 and Windows XP:  Closing the completion port handle while a call is outstanding will not result in the previously stated behavior. The function will continue to wait until an entry is removed from the port or until a time-out occurs, if specified as a value other than INFINITE.</para>
        /// <para>If theGetQueuedCompletionStatus function succeeds, it dequeued a completion packet for a successful I/O operation from the completion port and has stored information in the variables pointed to by the following parameters: lpNumberOfBytes, lpCompletionKey, and lpOverlapped. Upon failure (the return value is FALSE), those same parameters can contain particular value combinations as follows:</para>
        /// <para>If *lpOverlapped is NULL, the function did not dequeue a completion packet from the completion port. In this case, the function does not store information in the variables pointed to by the lpNumberOfBytes and lpCompletionKey parameters, and their values are indeterminate.</para>
        /// <para>If *lpOverlapped is not NULL and the function dequeues a completion packet for a failed I/O operation from the completion port, the function stores information about the failed operation in the variables pointed to by lpNumberOfBytes, lpCompletionKey, and lpOverlapped. To get extended error information, call GetLastError.</para>
        /// <para>For more information on I/O completion port theory, usage, and associated functions, see I/O Completion Ports.</para>
        /// <para>In Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
        /// </summary>
        /// <param name="CompletionPort">A handle to the completion port. To create a completion port, use the CreateIoCompletionPort function.</param>
        /// <param name="lpNumberOfBytes">A pointer to a variable that receives the number of bytes transferred during an I/O operation that has completed.</param>
        /// <param name="lpCompletionKey">A pointer to a variable that receives the completion key value associated with the file handle whose I/O operation has completed. A completion key is a per-file key that is specified in a call to CreateIoCompletionPort.</param>
        /// <param name="lpOverlapped">A pointer to a variable that receives the address of the OVERLAPPED structure that was specified when the completed I/O operation was started.Even if you have passed the function a file handle associated with a completion port and a valid OVERLAPPED structure, an application can prevent completion port notification. This is done by specifying a valid event handle for the hEvent member of the OVERLAPPED structure, and setting its low-order bit. A valid event handle whose low-order bit is set keeps I/O completion from being queued to the completion port.</param>
        /// <param name="dwMilliseconds">The number of milliseconds that the caller is willing to wait for a completion packet to appear at the completion port. If a completion packet does not appear within the specified time, the function times out, returns FALSE, and sets *lpOverlapped to NULL.If dwMilliseconds is INFINITE, the function will never time out. If dwMilliseconds is zero and there is no I/O operation to dequeue, the function will time out immediately.</param>
        /// <returns>Returns nonzero (TRUE) if successful or zero (FALSE) otherwise.To get extended error information, call GetLastError.For more information, see the Remarks section.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetQueuedCompletionStatus(IntPtr CompletionPort, out int lpNumberOfBytes, out IntPtr lpCompletionKey, out IntPtr lpOverlapped, int dwMilliseconds);

        /// <summary>
        /// <para>功能:</para>
        /// <para>Retrieves multiple completion port entries simultaneously. It waits for pending I/O operations that are associated with the specified completion port to complete.</para>
        /// <para>To dequeue I/O completion packets one at a time, use the GetQueuedCompletionStatus function.</para>
        /// <para>备注:</para>
        /// <para>This function associates a thread with the specified completion port. A thread can be associated with at most one completion port.</para>
        /// <para>This function returns TRUE when at least one pending I/O is completed, but it is possible that one or more I/O operations failed. Note that it is up to the user of this function to check the list of returned entries in the lpCompletionPortEntries parameter to determine which of them correspond to any possible failed I/O operations by looking at the status contained in the lpOverlapped member in each OVERLAPPED_ENTRY.</para>
        /// <para>This function returns FALSE when no I/O operation was dequeued. This typically means that an error occurred while processing the parameters to this call, or that the CompletionPort handle was closed or is otherwise invalid. The GetLastError function provides extended error information.</para>
        /// <para>If a call to GetQueuedCompletionStatusEx fails because the handle associated with it is closed, the function returns FALSE and GetLastError will return ERROR_ABANDONED_WAIT_0.</para>
        /// <para>Server applications may have several threads calling the GetQueuedCompletionStatusEx function for the same completion port. As I/O operations complete, they are queued to this port in first-in-first-out order. If a thread is actively waiting on this call, one or more queued requests complete the call for that thread only.</para>
        /// <para>For more information on I/O completion port theory, usage, and associated functions, see I/O Completion Ports.</para>
        /// <para>In Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
        /// </summary>
        /// <param name="CompletionPort">A handle to the completion port. To create a completion port, use the CreateIoCompletionPort function.</param>
        /// <param name="lpCompletionPortEntries">On input, points to a pre-allocated array of OVERLAPPED_ENTRY structures.On output, receives an array of OVERLAPPED_ENTRY structures that hold the entries. The number of array elements is provided by ulNumEntriesRemoved.The number of bytes transferred during each I/O, the completion key that indicates on which file each I/O occurred, and the overlapped structure address used in each original I/O are all returned in the lpCompletionPortEntries array.</param>
        /// <param name="ulCount">The maximum number of entries to remove.</param>
        /// <param name="ulNumEntriesRemoved">A pointer to a variable that receives the number of entries actually removed.</param>
        /// <param name="dwMilliseconds">The number of milliseconds that the caller is willing to wait for a completion packet to appear at the completion port. If a completion packet does not appear within the specified time, the function times out and returns FALSE.If dwMilliseconds is INFINITE (0xFFFFFFFF), the function will never time out. If dwMilliseconds is zero and there is no I/O operation to dequeue, the function will time out immediately.</param>
        /// <param name="fAlertable">If this parameter is FALSE, the function does not return until the time-out period has elapsed or an entry is retrieved.If the parameter is TRUE and there are no available entries, the function performs an alertable wait. The thread returns when the system queues an I/O completion routine or APC to the thread and the thread executes the function.A completion routine is queued when the ReadFileEx or WriteFileEx function in which it was specified has completed, and the calling thread is the thread that initiated the operation. An APC is queued when you call QueueUserAPC.</param>
        /// <returns>Returns nonzero (TRUE) if successful or zero (FALSE) otherwise.To get extended error information, call GetLastError.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetQueuedCompletionStatusEx(IntPtr CompletionPort, out IntPtr lpCompletionPortEntries, int ulCount, out int ulNumEntriesRemoved, int dwMilliseconds, bool fAlertable);

        /// <summary>
        /// <para>功能:</para>
        /// <para>Posts an I/O completion packet to an I/O completion port.</para>
        /// <para>备注:</para>
        /// <para>The I/O completion packet will satisfy an outstanding call to the GetQueuedCompletionStatus function. This function returns with the three values passed as the second, third, and fourth parameters of the call to PostQueuedCompletionStatus. The system does not use or validate these values. In particular, the lpOverlapped parameter need not point to an OVERLAPPED structure.</para>
        /// <para>In Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
        /// </summary>
        /// <param name="CompletionPort">A handle to an I/O completion port to which the I/O completion packet is to be posted.</param>
        /// <param name="dwNumberOfBytesTransferred">The value to be returned through the lpNumberOfBytesTransferred parameter of the GetQueuedCompletionStatus function.</param>
        /// <param name="dwCompletionKey">The value to be returned through the lpCompletionKey parameter of the GetQueuedCompletionStatus function.</param>
        /// <param name="lpOverlapped">The value to be returned through the lpOverlapped parameter of the GetQueuedCompletionStatus function.</param>
        /// <returns>If the function succeeds, the return value is nonzero.If the function fails, the return value is zero. To get extended error information, call GetLastError .</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PostQueuedCompletionStatus(IntPtr CompletionPort, int dwNumberOfBytesTransferred, IntPtr dwCompletionKey, IntPtr lpOverlapped);

        /// <summary>
        /// <para>功能:</para>
        /// <para>Marks any outstanding I/O operations for the specified file handle. The function only cancels I/O operations in the current process, regardless of which thread created the I/O operation.</para>
        /// <para>备注:</para>
        /// <para>The CancelIoEx function allows you to cancel requests in threads other than the calling thread. The CancelIo function only cancels requests in the same thread that called the CancelIo function. CancelIoEx cancels only outstanding I/O on the handle, it does not change the state of the handle; this means that you cannot rely on the state of the handle because you cannot know whether the operation was completed successfully or canceled.</para>
        /// <para>If there are any pending I/O operations in progress for the specified file handle, the CancelIoEx function marks them for cancellation. Most types of operations can be canceled immediately; other operations can continue toward completion before they are actually canceled and the caller is notified. The CancelIoEx function does not wait for all canceled operations to complete.</para>
        /// <para>If the file handle is associated with a completion port, an I/O completion packet is not queued to the port if a synchronous operation is successfully canceled. For asynchronous operations still pending, the cancel operation will queue an I/O completion packet.</para>
        /// <para>The operation being canceled is completed with one of three statuses; you must check the completion status to determine the completion state. The three statuses are:</para>
        /// <para>The operation completed normally. This can occur even if the operation was canceled, because the cancel request might not have been submitted in time to cancel the operation.</para>
        /// <para>The operation was canceled. The GetLastError function returns ERROR_OPERATION_ABORTED.</para>
        /// <para>The operation failed with another error. The GetLastError function returns the relevant error code.</para>
        /// <para>In Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
        /// </summary>
        /// <param name="hFile">A handle to the file.</param>
        /// <param name="lpOverlapped">A pointer to an OVERLAPPED data structure that contains the data used for asynchronous I/O.If this parameter is NULL, all I/O requests for the hFile parameter are canceled.If this parameter is not NULL, only those specific I/O requests that were issued for the file with the specified lpOverlapped overlapped structure are marked as canceled, meaning that you can cancel one or more requests, while the CancelIo function cancels all outstanding requests on a file handle.</param>
        /// <returns>If the function succeeds, the return value is nonzero. The cancel operation for all pending I/O operations issued by the calling process for the specified file handle was successfully requested. The application must not free or reuse the OVERLAPPED structure associated with the canceled I/O operations until they have completed. The thread can use the GetOverlappedResult function to determine when the I/O operations themselves have been completed.If the function fails, the return value is 0 (zero). To get extended error information, call the GetLastError function.If this function cannot find a request to cancel, the return value is 0 (zero), and GetLastError returns ERROR_NOT_FOUND.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CancelIoEx(IntPtr hFile, IntPtr lpOverlapped);

        #endregion


        #region Handle and Object Functions                         句柄和对象函数

        /// <summary>
        /// <para>功能:</para>
        /// <para>Closes an open object handle.</para>
        /// <para>备注:</para>
        /// <para>The CloseHandle function closes handles to the following objects:</para>
        /// <para>Access token</para>
        /// <para>Communications device</para>
        /// <para>Console input</para>
        /// <para>Console screen buffer</para>
        /// <para>Event</para>
        /// <para>File</para>
        /// <para>File mapping</para>
        /// <para>I/O completion port</para>
        /// <para>Job</para>
        /// <para>Mailslot</para>
        /// <para>Memory resource notification</para>
        /// <para>Mutex</para>
        /// <para>Named pipe</para>
        /// <para>Pipe</para>
        /// <para>Process</para>
        /// <para>Semaphore</para>
        /// <para>Thread</para>
        /// <para>Transaction</para>
        /// <para>Waitable timer</para>
        /// <para>The documentation for the functions that create these objects indicates that CloseHandle should be used when you are finished with the object, and what happens to pending operations on the object after the handle is closed. In general, CloseHandle invalidates the specified object handle, decrements the object&apos;s handle count, and performs object retention checks. After the last handle to an object is closed, the object is removed from the system. For a summary of the creator functions for these objects, see Kernel Objects.</para>
        /// <para>Generally, an application should call CloseHandle once for each handle it opens. It is usually not necessary to call CloseHandle if a function that uses a handle fails with ERROR_INVALID_HANDLE, because this error usually indicates that the handle is already invalidated. However, some functions use ERROR_INVALID_HANDLE to indicate that the object itself is no longer valid. For example, a function that attempts to use a handle to a file on a network might fail with ERROR_INVALID_HANDLE if the network connection is severed, because the file object is no longer available. In this case, the application should close the handle.</para>
        /// <para>If a handle is transacted, all handles bound to a transaction should be closed before the transaction is committed. If a transacted handle was opened by calling CreateFileTransacted with the FILE_FLAG_DELETE_ON_CLOSE flag, the file is not deleted until the application closes the handle and calls CommitTransaction. For more information about transacted objects, see Working With Transactions.</para>
        /// <para>Closing a thread handle does not terminate the associated thread or remove the thread object. Closing a process handle does not terminate the associated process or remove the process object. To remove a thread object, you must terminate the thread, then close all handles to the thread. For more information, see Terminating a Thread. To remove a process object, you must terminate the process, then close all handles to the process. For more information, see Terminating a Process.</para>
        /// <para>Closing a handle to a file mapping can succeed even when there are file views that are still open. For more information, see Closing a File Mapping Object.</para>
        /// <para>Do not use the CloseHandle function to close a socket. Instead, use the closesocket function, which releases all resources associated with the socket including the handle to the socket object. For more information, see Socket Closure.</para>
        /// </summary>
        /// <param name="hObject">A valid handle to an open object.</param>
        /// <returns>If the function succeeds, the return value is nonzero.If the function fails, the return value is zero. To get extended error information, call GetLastError.If the application is running under a debugger, the function will throw an exception if it receives either a handle value that is not valid or a pseudo-handle value. This can happen if you close a handle twice, or if you call CloseHandle on a handle returned by the FindFirstFile function instead of calling the FindClose function.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseHandle(IntPtr hObject);

        #endregion
    }
}
