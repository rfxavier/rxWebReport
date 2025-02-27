using MQTTnet;
using MQTTnet.Client.Options;
using MQTTnet.Extensions.ManagedClient;
using MQTTnet.Formatter;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;

namespace rxWebReport.mqttClient
{
    public class MqttClientHandler
    {
        public IManagedMqttClient managedMqttClientPublisher;

        public void PublisherStart()
        {
            var mqttFactory = new MqttFactory();

            var tlsOptions = new MqttClientTlsOptions
            {
                UseTls = false,
                IgnoreCertificateChainErrors = true,
                IgnoreCertificateRevocationErrors = true,
                AllowUntrustedCertificates = true
            };

            var options = new MqttClientOptions
            {
                ClientId = $"ClientPublisherGetLock{Guid.NewGuid()}",
                ProtocolVersion = MqttProtocolVersion.V311,
                ChannelOptions = new MqttClientTcpOptions
                {
                    Server = ConfigurationManager.AppSettings["mqttServer"],
                    Port = int.Parse(ConfigurationManager.AppSettings["mqttServerPort"]),
                    TlsOptions = tlsOptions
                }
            };

            if (options.ChannelOptions == null)
            {
                throw new InvalidOperationException();
            }

            options.Credentials = new MqttClientCredentials
            {
                Username = ConfigurationManager.AppSettings["mqttServerUsername"],
                Password = Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["mqttServerPassword"])
            };

            options.CleanSession = true;
            options.KeepAlivePeriod = TimeSpan.FromSeconds(5);
            this.managedMqttClientPublisher = mqttFactory.CreateManagedMqttClient();
            //this.managedMqttClientPublisher.UseApplicationMessageReceivedHandler(this.HandleReceivedApplicationMessage);
            //this.managedMqttClientPublisher.ConnectedHandler = new MqttClientConnectedHandlerDelegate(OnPublisherConnected);
            //this.managedMqttClientPublisher.DisconnectedHandler = new MqttClientDisconnectedHandlerDelegate(OnPublisherDisconnected);

            this.managedMqttClientPublisher.StartAsync(
                new ManagedMqttClientOptions
                {
                    ClientOptions = options
                });
        }

        public void PublisherStop()
        {
            if (this.managedMqttClientPublisher == null)
            {
                return;
            }

            this.managedMqttClientPublisher.StopAsync();
            this.managedMqttClientPublisher = null;
        }


    }
}