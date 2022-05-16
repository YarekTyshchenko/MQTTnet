using System;

namespace MQTTnet.Server
{
    
    public class Tenanting
    {
        /// <summary>
        /// Is this session allowed to receive this message?
        /// Used for organization sharding
        /// </summary>
        /// <param name="applicationMessage"></param>
        /// <param name="session"></param>
        /// <returns></returns>
        public static bool CanSessionReceiveMessage(MqttApplicationMessage applicationMessage, MqttSession session)
        {
            if (!session.Items.Contains("OrganizationId"))
            {
                throw new Exception("OrganizationId is missing from session so cannot send it messages");
            }

            var sessionOrgId = (string)session.Items["OrganizationId"];
            foreach (var userProperty in applicationMessage.UserProperties)
            {
                if (userProperty.Name == "OrganizationId")
                {
                    if (userProperty.Value == sessionOrgId)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            throw new Exception("OrganizationId is missing from UserProperties of message, so cannot send");
        }
    }
}
