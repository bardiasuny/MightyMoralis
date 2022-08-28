using MoralisUnity;
using MoralisUnity.Kits.AuthenticationKit;
using RestSharp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoralisUnity.Demos.Introduction
{
    public class UIController : MonoBehaviour
    {

        [SerializeField]
        private GameObject authenticationKitObject = null;

        [SerializeField]
        private GameObject congratulationUiObject = null;

        [SerializeField]
        private GameObject fireworksObject = null;

        private AuthenticationKit authKit = null;

        private void Start()
        {
            authKit = authenticationKitObject.GetComponent<AuthenticationKit>();


            var client = new RestClient("https://eth-mainnet.g.alchemy.com/nft/v2/ffSqd83ZiR36Pay-y5ShWkS6ffGxs0Nl/getFloorPrice");
            var request = new RestRequest(Method.Get.ToString());
            request.AddHeader("Accept", "application/json");
            RestResponse response = client.Execute(request);
            print(response)
        }
        public void Authentication_OnConnect()
        {
            authenticationKitObject.SetActive(false);
            congratulationUiObject.SetActive(true);
            fireworksObject.SetActive(true);
        }

        public void LogoutButton_OnClicked()
        {
            // Logout the Moralis User.
            authKit.Disconnect();

            authenticationKitObject.SetActive(true);
            congratulationUiObject.SetActive(false);
            fireworksObject.SetActive(true);
        }
    }
}
