Deploy to production

To deploy the app to production, the following resources need to be provisioned:

    A database to store the Identity user accounts and the IdentityServer grants.
    A production certificate to use for signing tokens.
        There are no specific requirements for this certificate; it can be a self-signed certificate or a certificate provisioned through a CA authority.
        It can be generated through standard tools like PowerShell or OpenSSL.
        It can be installed into the certificate store on the target machines or deployed as a .pfx file with a strong password.
