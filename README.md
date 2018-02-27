# IndentityServer1
Identity Server 4 
This project contains
1) Identity Server 4 running on port 5000
2) .Net Core Web API running on port 5001
3) Console Client

Goto the Identity Server URL http://localhost:5000/.well-known/openid-configuration
you should see the so-called discovery document. This will be used by your clients and APIs to download the necessary configuration data.

Goto http://localhost:5001/identity it should fail with a 401

The console app first discovers the endpoints
Then gets a bearer token
Then makes a request to the http://localhost:5001/identity controller

NB: Notice the statup config in API notice options.Authority = "http://localhost:5000";

This means that the API is TRUSTING token requests from the identity server running on port 5000 



Setup documented here http://docs.identityserver.io/en/release/quickstarts/0_overview.html
Then here for the tutorial used to create this demo http://docs.identityserver.io/en/release/quickstarts/1_client_credentials.html
