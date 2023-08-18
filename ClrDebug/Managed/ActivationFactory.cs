namespace ClrDebug
{
    public class ActivationFactory : Inspectable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActivationFactory"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public ActivationFactory(IActivationFactory raw) : base(raw)
        {
        }

        #region IActivationFactory

        public new IActivationFactory Raw => (IActivationFactory) base.Raw;

        #region ActivateInstance

        public Inspectable ActivateInstance()
        {
            Inspectable instanceResult;
            TryActivateInstance(out instanceResult).ThrowOnNotOK();

            return instanceResult;
        }

        public HRESULT TryActivateInstance(out Inspectable instanceResult)
        {
            /*HRESULT ActivateInstance(
            [Out] out IInspectable instance);*/
            IInspectable instance;
            HRESULT hr = Raw.ActivateInstance(out instance);

            if (hr == HRESULT.S_OK)
                instanceResult = new Inspectable(instance);
            else
                instanceResult = default(Inspectable);

            return hr;
        }

        #endregion
        #endregion
    }
}
