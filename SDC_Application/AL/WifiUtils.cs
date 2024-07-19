using System;
using System.Collections.Generic;
using System.Text;
//using ManagedWifi;
using NativeWifi;

public class WifiUtils
{
    public   string[] GetVisibleWifiSSIDs()
    {
        List<string> ssidList = new List<string>();
        WlanClient client = new WlanClient();

        foreach (WlanClient.WlanInterface wlanIface in client.Interfaces)
        {
            try
            {
                Wlan.WlanAvailableNetwork[] networks = wlanIface.GetAvailableNetworkList(0);
                foreach (Wlan.WlanAvailableNetwork network in networks)
                {
                    string ssid = Encoding.ASCII.GetString(network.dot11Ssid.SSID).TrimEnd('\0');
                    if (!string.IsNullOrEmpty(ssid))
                    {
                        ssidList.Add(ssid);
                    }
                }
            }
            catch (Exception ex)
            {

                //throw;
            }
            

        }

        return ssidList.ToArray();
    }

    public   string ConvertToCsv(string[] inputArray)
    {
        if (inputArray == null || inputArray.Length == 0)
        {
            return string.Empty;
        }

        List<string> nonEmptyStrings = new List<string>();
        foreach (var str in inputArray)
        {
            if (!string.IsNullOrEmpty(str))
            {
                nonEmptyStrings.Add(str);
            }
        }

        return string.Join(", ", nonEmptyStrings);
    }

    public string GetVisibleWifiSSIDs_CSV()
    {
        return ConvertToCsv(GetVisibleWifiSSIDs());
    }

}
