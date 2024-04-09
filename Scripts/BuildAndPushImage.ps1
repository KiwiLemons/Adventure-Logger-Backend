
$response = Read-Host -Prompt 'Are you sure you want to build and push to the cloud? [Y/n]'

if ($response -eq 'n') {
	Exit
}


docker build -t webserver-image -f Dockerfile .
docker tag webserver-image us-central1-docker.pkg.dev/adventure-logger-408520/webserver/test-image:latest
docker push us-central1-docker.pkg.dev/adventure-logger-408520/webserver/test-image:latest
gcloud run deploy webserver-image --image=us-central1-docker.pkg.dev/adventure-logger-408520/webserver/test-image:latest --region=us-central1