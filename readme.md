We want to be able to spin up multiple asp.net core containers - 'listening' on different domains for local testing.

For example https://app1.local and https://app2.local

I'm using [jwilder/nginx-proxy](https://hub.docker.com/r/jwilder/nginx-proxy/) to provide a proxy.  

This allows us to specify a `VIRTUAL_HOST` environment variable, and automatically be mapped in the nginx container.


This would be 'easy' if we didn't need to use https.  


To try to get https to work, I'm using [aegypius/mkcert-for-nginx-proxy](https://github.com/aegypius/mkcert-for-nginx-proxy)
But I'm pretty sure this isn't configured correctly.  


**Add this to hosts file**  
127.0.0.1  app1.local  
127.0.0.1  app2.local  

Run 
`docker-compose up`

Notice it will output

    mkcert_1       | Using the local CA at "/app/ca" ✨
    mkcert_1       | Warning: the local CA is not installed in the Firefox and/or Chrome/Chromium trust store! ⚠️
    mkcert_1       | Run "mkcert -install" to avoid verification errors ‼️

ctrl+c to stop the containers, then run

`mkcert -install` to install the CA

Run the containers again with `docker-compose up`

Now, `https://app1.local` should resolve in the browser, but you'll get a certificate error.
