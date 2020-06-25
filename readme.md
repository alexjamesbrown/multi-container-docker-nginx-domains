We want to be able to spin up multiple asp.net core containers - 'listening' on different domains for local testing.

For example https://app1.local and https://app2.local

I'm using [jwilder/nginx-proxy](https://hub.docker.com/r/jwilder/nginx-proxy/) to provide a proxy.  

This allows us to specify a `VIRTUAL_HOST` environment variable, and automatically be mapped in the nginx container.

## Getting started

**Add this to hosts file**  
127.0.0.1  app1.local  
127.0.0.1  app2.local  

**Install mkcert**  
https://github.com/FiloSottile/mkcert

Once installed, we need to create a new local CA.  
Run this on cmd line:  
`mkcert -install` 

Now, run 
`docker-compose up`

Now, both urls should work:
- `https://app1.local` 
- `https://app2.local` 



## Possible Extra Step...
I'm not 100% sure if this will work "out of the box" with the certs checked in - 
You may need to recreate the certificates in the `/certs` folder.  

To do this, ensure the containers aren't running, and delete the `/certs` dir.

Then run:

`mkdir certs`  
followed by  

`mkcert -key-file certs\app1.local.key -cert-file certs\app1.local.crt app1.local`

`mkcert -key-file certs\app2.local.key -cert-file certs\app2.local.crt app2.local`

This will create certs for app1.local and app2.local, in the `/certs` directory, which is mounted as a volume by the proxy.