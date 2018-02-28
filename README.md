# IndentityServer Test Project
 
This project contains
1) IdentityServer 4 running on port 5000
2) Dotnet Core Web API running on port 5001
3) Console Client

# Starting...

The API is trusting the IdentityServer, so IdentityServer needs to be running before we start the API.
The Solution is set to start the <b>IdentityServer project only</b>.
        <ul>
            <li>
                Click the play button in VS, this will start IdentityServer on port 5000, once it's up and running, click stop.
            </li>
            <li>
                Then RightClick the API Project  > Debug > Start New Instance, this will start the API on port 5001
            </li>
            <li>
                Then RightClick the Client Project > Debug > Start New Instance , the Client project will run quickly, add some breakpoints in Program.cs
            </li>
        </ul>

# Debugging...
To understand how the application works:
    <ul>
        <li>
            Goto the Identity Server  http://localhost:5000/.well-known/openid-configuration
        you should see the so-called discovery document. This will be used by your clients and APIs to download the necessary configuration data.
    </li>
    <li>
        Goto http://localhost:5001/identity it should fail with a 401, that's because you don't have a token.
    </li>
        <li>
            The console app first discovers the endpoints</br>
            Then gets a bearer token</br>
            Then makes a request to the http://localhost:5001/identity controller.</br>
        </li>
    </ul>



# NB: 
Go to the startup.cs for the API project, notice <b>options.Authority = http://localhost:5000: </b>/br>
This configures the API to TRUST token requests from the IdentityServer.
    <ul>
        <li>
         How to setup IdentityServer From VS http://docs.identityserver.io/en/release/quickstarts/0_overview.html
        </li>
        <li>
        Tutorial used to create this solution http://docs.identityserver.io/en/release/quickstarts/1_client_credentials.html
        </li>
    </ul>