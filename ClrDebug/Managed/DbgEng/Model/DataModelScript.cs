using System.Diagnostics;
using ClrDebug;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// An abstraction of a particular script which is being managed by the provider. Each script which is loaded or being edited has a separate IDataModelScript instance.<para/>
    /// Any script provider must implement this to represent a script managed by that provider.
    /// </summary>
    public class DataModelScript : ComObject<IDataModelScript>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataModelScript"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DataModelScript(IDataModelScript raw) : base(raw)
        {
        }

        #region IDataModelScript
        #region Name

        /// <summary>
        /// The GetName method returns the name of the script as an allocated string via the SysAllocString function. If the script does not yet have a name, the method should return a null BSTR.<para/>
        /// It should not fail in this circumstance. If the script is explicitly renamed via a call to the Rename method, the GetName method should return the newly assigned name.
        /// </summary>
        public string Name
        {
            get
            {
                string scriptName;
                TryGetName(out scriptName).ThrowDbgEngNotOK();

                return scriptName;
            }
        }

        /// <summary>
        /// The GetName method returns the name of the script as an allocated string via the SysAllocString function. If the script does not yet have a name, the method should return a null BSTR.<para/>
        /// It should not fail in this circumstance. If the script is explicitly renamed via a call to the Rename method, the GetName method should return the newly assigned name.
        /// </summary>
        /// <param name="scriptName">The name of the script should be returned here as a string allocated via SysAllocString. The caller is responsible for freeing this string via the SysFreeString method.<para/>
        /// Note that if the script is unnamed, the method should return a null BSTR as the output. It should still succeed in this case.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetName(out string scriptName)
        {
            /*HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string scriptName);*/
            return Raw.GetName(out scriptName);
        }

        #endregion
        #region IsInvocable

        /// <summary>
        /// The IsInvocable method returns whether or not the script is invocable -- that is, whether it has a "main function" as defined by its language or provider.<para/>
        /// Such a "main function" is conceptually something that the script author would want called if an imaginary "Execute Script" button were pressed in a user interface.<para/>
        /// This method is only legal to call after a successful call to the Execute method. Calling this method when a script has not yet executed (or has unlinked) is illegal and should produce an error.
        /// </summary>
        public bool IsInvocable
        {
            get
            {
                bool isInvocable;
                TryIsInvocable(out isInvocable).ThrowDbgEngNotOK();

                return isInvocable;
            }
        }

        /// <summary>
        /// The IsInvocable method returns whether or not the script is invocable -- that is, whether it has a "main function" as defined by its language or provider.<para/>
        /// Such a "main function" is conceptually something that the script author would want called if an imaginary "Execute Script" button were pressed in a user interface.<para/>
        /// This method is only legal to call after a successful call to the Execute method. Calling this method when a script has not yet executed (or has unlinked) is illegal and should produce an error.
        /// </summary>
        /// <param name="isInvocable">An indication of whether the script is invocable is returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryIsInvocable(out bool isInvocable)
        {
            /*HRESULT IsInvocable(
            [Out, MarshalAs(UnmanagedType.U1)] out bool isInvocable);*/
            return Raw.IsInvocable(out isInvocable);
        }

        #endregion
        #region Rename

        /// <summary>
        /// The Rename method assigns a new name to the script. It is the responsibility of the script implementation to save this name and return it upon any call to the GetName method.<para/>
        /// This is often called when a user interface chooses to Save As the script to a new name. Note that renaming the script may affect where the hosting application chooses to project the contents of the script.
        /// </summary>
        /// <param name="scriptName">The name being assigned to the script is passed here.</param>
        public void Rename(string scriptName)
        {
            TryRename(scriptName).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The Rename method assigns a new name to the script. It is the responsibility of the script implementation to save this name and return it upon any call to the GetName method.<para/>
        /// This is often called when a user interface chooses to Save As the script to a new name. Note that renaming the script may affect where the hosting application chooses to project the contents of the script.
        /// </summary>
        /// <param name="scriptName">The name being assigned to the script is passed here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryRename(string scriptName)
        {
            /*HRESULT Rename(
            [In, MarshalAs(UnmanagedType.LPWStr)] string scriptName);*/
            return Raw.Rename(scriptName);
        }

        #endregion
        #region Populate

        /// <summary>
        /// The Populate method is called by the client in order to change or synchronize the "content" of the script. It is the notification that is made to the script provider that the code of the script has changed.<para/>
        /// It is important to note that this method does not cause execution of the script or changes to any of the objects that the script manipulates.<para/>
        /// This is merely a notification to the script provider that the content of the script has changed so that it may synchronize its own internal state.<para/>
        /// The implementer of the Populate method may not hold the content stream between the Populate and Execute calls. It must synchronize any internal state and data structures to "remember" the script content after the Populate call returns.<para/>
        /// It is also important to note that the implementation should not discard the state representing the currently executed version of the script until after an Execute call succeeds.<para/>
        /// If the populated content has syntax or other errors that prevent successful execution of the script, the provider must restore the state of the script to what was successfully executed.
        /// </summary>
        /// <param name="contentStream">A standard input stream representing the content of the entire script is passed here. The implementation must "remember" this content (or a data structure based form of it) after the Populate method returns.<para/>
        /// It is illegal to hold a reference to the passed stream after returning. Such will cause undefined behavior in the host.</param>
        public void Populate(IStream contentStream)
        {
            TryPopulate(contentStream).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The Populate method is called by the client in order to change or synchronize the "content" of the script. It is the notification that is made to the script provider that the code of the script has changed.<para/>
        /// It is important to note that this method does not cause execution of the script or changes to any of the objects that the script manipulates.<para/>
        /// This is merely a notification to the script provider that the content of the script has changed so that it may synchronize its own internal state.<para/>
        /// The implementer of the Populate method may not hold the content stream between the Populate and Execute calls. It must synchronize any internal state and data structures to "remember" the script content after the Populate call returns.<para/>
        /// It is also important to note that the implementation should not discard the state representing the currently executed version of the script until after an Execute call succeeds.<para/>
        /// If the populated content has syntax or other errors that prevent successful execution of the script, the provider must restore the state of the script to what was successfully executed.
        /// </summary>
        /// <param name="contentStream">A standard input stream representing the content of the entire script is passed here. The implementation must "remember" this content (or a data structure based form of it) after the Populate method returns.<para/>
        /// It is illegal to hold a reference to the passed stream after returning. Such will cause undefined behavior in the host.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryPopulate(IStream contentStream)
        {
            /*HRESULT Populate(
            [In, MarshalAs(UnmanagedType.Interface)] IStream contentStream);*/
            return Raw.Populate(contentStream);
        }

        #endregion
        #region Execute

        /// <summary>
        /// The Execute method executes the content of the script as dictated by the last successful Populate call and modifies the object model of the debugger according to that content.<para/>
        /// If the language (or the script provider) defines a "main function" -- one that the author would want called upon clicking an imaginary "Execute Script" button in a user interface -- such "main function" is not called during an Execute operation.<para/>
        /// The Execute operation can be considered to perform initialization and object model manipulations only (e.g.: executing root code and setting up extensibility points).Execution of a script is a two way communication between the script provider and the script client.<para/>
        /// Errors, debugging control, and other semantics are passed across the communication channel between <see cref="IDataModelScript"/> and <see cref="IDataModelScriptClient"/>.<para/>
        /// Depending on whether the Execute operation succeeds or fails, one of two things should happen: For a successful return: o	The previously executed content of the script is flushed and forgotten o	Any object model manipulations or extensibility points changed as a result of the prior execution of the script are undone o	The object model manipulations and extensibility points of the new execution of the script are active For a failed return: o	Any manipulations or extensibility points of the new attempted execution of the script are undone o	The prior state of the script is restored.<para/>
        /// All its object model manipulations and extensibility points are restored. o	The state should be as it was after the successful Populate call but before any Execute call Note that for a properly written script provider and scripting environment, calling the Execute method multiple times without an intervening call to Populate or Unlink 'should be idempotent.<para/>
        /// That is, calling Execute N times in a row should appear to the user the same as calling Execute once. The execution should not produce side effecting results on the state of the debug target.<para/>
        /// Subsequently utilizing properties, methods, or events on the bridge produced via the Execute method may indeed produce side effecting results.
        /// </summary>
        /// <param name="client">An interface to the client requesting the execution should be passed here. If there are errors or other events during execution of the script, the client should be notified of those and their location within the script via methods on this interface.</param>
        public void Execute(IDataModelScriptClient client)
        {
            TryExecute(client).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The Execute method executes the content of the script as dictated by the last successful Populate call and modifies the object model of the debugger according to that content.<para/>
        /// If the language (or the script provider) defines a "main function" -- one that the author would want called upon clicking an imaginary "Execute Script" button in a user interface -- such "main function" is not called during an Execute operation.<para/>
        /// The Execute operation can be considered to perform initialization and object model manipulations only (e.g.: executing root code and setting up extensibility points).Execution of a script is a two way communication between the script provider and the script client.<para/>
        /// Errors, debugging control, and other semantics are passed across the communication channel between <see cref="IDataModelScript"/> and <see cref="IDataModelScriptClient"/>.<para/>
        /// Depending on whether the Execute operation succeeds or fails, one of two things should happen: For a successful return: o	The previously executed content of the script is flushed and forgotten o	Any object model manipulations or extensibility points changed as a result of the prior execution of the script are undone o	The object model manipulations and extensibility points of the new execution of the script are active For a failed return: o	Any manipulations or extensibility points of the new attempted execution of the script are undone o	The prior state of the script is restored.<para/>
        /// All its object model manipulations and extensibility points are restored. o	The state should be as it was after the successful Populate call but before any Execute call Note that for a properly written script provider and scripting environment, calling the Execute method multiple times without an intervening call to Populate or Unlink 'should be idempotent.<para/>
        /// That is, calling Execute N times in a row should appear to the user the same as calling Execute once. The execution should not produce side effecting results on the state of the debug target.<para/>
        /// Subsequently utilizing properties, methods, or events on the bridge produced via the Execute method may indeed produce side effecting results.
        /// </summary>
        /// <param name="client">An interface to the client requesting the execution should be passed here. If there are errors or other events during execution of the script, the client should be notified of those and their location within the script via methods on this interface.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryExecute(IDataModelScriptClient client)
        {
            /*HRESULT Execute(
            [In, MarshalAs(UnmanagedType.Interface)] IDataModelScriptClient client);*/
            return Raw.Execute(client);
        }

        #endregion
        #region Unlink

        /// <summary>
        /// The Unlink method undoes the Execute operation. Any object model manipulations or extensibility points established during the execution of the script are undone.<para/>
        /// After an Unlink operation, the script may be re-executed via a call to Execute or it may be released. It is expected that this is called, for instance, upon the closing of a script window by a user interface client.<para/>
        /// After the Unlink call, the state of the script should be the same as if the following sequence of operations were performed on a new script:
        /// </summary>
        public void Unlink()
        {
            TryUnlink().ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The Unlink method undoes the Execute operation. Any object model manipulations or extensibility points established during the execution of the script are undone.<para/>
        /// After an Unlink operation, the script may be re-executed via a call to Execute or it may be released. It is expected that this is called, for instance, upon the closing of a script window by a user interface client.<para/>
        /// After the Unlink call, the state of the script should be the same as if the following sequence of operations were performed on a new script:
        /// </summary>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryUnlink()
        {
            /*HRESULT Unlink();*/
            return Raw.Unlink();
        }

        #endregion
        #region InvokeMain

        /// <summary>
        /// If the script has a "main function" which is intended to execute from a UI invocation, it indicates such via a true return from the IsInvocable method.<para/>
        /// The user interface can then call the InvokeMain method to actually "invoke" the script. Note that this is distinct from Execute which runs all root code and bridges the script to the namespace of the underlying host.<para/>
        /// This method may fail with E_NOTIMPL if the script does not contain a "main function" or the provider does not define such.<para/>
        /// Note that an application which hosts the data model may load and execute a script once but call the InvokeMain method an arbitrary number of times without an intervening Execute call.<para/>
        /// It is expected that this would preserve the "script context", keep the script loaded, and just call a method within the script multiple times.<para/>
        /// If there are errors or other events which occur during execution of the script, such (and their location within the script) can be passed across the communication channel between the <see cref="IDataModelScript"/> and the inpassed <see cref="IDataModelScriptClient"/>.
        /// </summary>
        /// <param name="client">An interface to the client which is requesting the main function be called. If there are errors or other events which occur during execution of the main function, the script can pass this information and its location within the script back to the client via method calls on this interface.</param>
        public void InvokeMain(IDataModelScriptClient client)
        {
            TryInvokeMain(client).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// If the script has a "main function" which is intended to execute from a UI invocation, it indicates such via a true return from the IsInvocable method.<para/>
        /// The user interface can then call the InvokeMain method to actually "invoke" the script. Note that this is distinct from Execute which runs all root code and bridges the script to the namespace of the underlying host.<para/>
        /// This method may fail with E_NOTIMPL if the script does not contain a "main function" or the provider does not define such.<para/>
        /// Note that an application which hosts the data model may load and execute a script once but call the InvokeMain method an arbitrary number of times without an intervening Execute call.<para/>
        /// It is expected that this would preserve the "script context", keep the script loaded, and just call a method within the script multiple times.<para/>
        /// If there are errors or other events which occur during execution of the script, such (and their location within the script) can be passed across the communication channel between the <see cref="IDataModelScript"/> and the inpassed <see cref="IDataModelScriptClient"/>.
        /// </summary>
        /// <param name="client">An interface to the client which is requesting the main function be called. If there are errors or other events which occur during execution of the main function, the script can pass this information and its location within the script back to the client via method calls on this interface.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryInvokeMain(IDataModelScriptClient client)
        {
            /*HRESULT InvokeMain(
            [In, MarshalAs(UnmanagedType.Interface)] IDataModelScriptClient client);*/
            return Raw.InvokeMain(client);
        }

        #endregion
        #endregion
        #region IDataModelScript2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDataModelScript2 Raw2 => (IDataModelScript2) Raw;

        #region ScriptFullFilePathName

        public string ScriptFullFilePathName
        {
            get
            {
                string scriptFullPathName;
                TryGetScriptFullFilePathName(out scriptFullPathName).ThrowDbgEngNotOK();

                return scriptFullPathName;
            }
            set
            {
                TrySetScriptFullFilePathName(value).ThrowDbgEngNotOK();
            }
        }

        public HRESULT TryGetScriptFullFilePathName(out string scriptFullPathName)
        {
            /*HRESULT GetScriptFullFilePathName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string scriptFullPathName);*/
            return Raw2.GetScriptFullFilePathName(out scriptFullPathName);
        }

        public HRESULT TrySetScriptFullFilePathName(string scriptFullPathName)
        {
            /*HRESULT SetScriptFullFilePathName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string scriptFullPathName);*/
            return Raw2.SetScriptFullFilePathName(scriptFullPathName);
        }

        #endregion
        #endregion

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
