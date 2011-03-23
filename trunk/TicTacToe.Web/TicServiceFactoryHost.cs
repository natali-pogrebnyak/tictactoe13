using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Activation;

namespace TicTacToe.Web
{
    public class TicServiceFactoryHost : ServiceHostFactoryBase
    {
        public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
        {
            return new TicServiceHost (baseAddresses);
        }
    }

    class TicServiceHost : ServiceHost
    {
        public TicServiceHost(params Uri[] addresses)
        {
            base.InitializeDescription(typeof(TicService), new UriSchemeKeyedCollection(addresses));
        }

        protected override void InitializeRuntime()
        {
            PollingDuplexBindingElement pdbe = new PollingDuplexBindingElement()
            {
                ServerPollTimeout = TimeSpan.FromSeconds(3),
                //Duration to wait before the channel is closed due to inactivity
                InactivityTimeout = TimeSpan.FromMinutes(10)
            };

            this.AddServiceEndpoint(typeof(TicService), 
                new CustomBinding(
                    pdbe,
                    new BinaryMessageEncodingBindingElement(),
                    new HttpTransportBindingElement()),
                string.Empty);
            base.InitializeRuntime();
        }
    }
}