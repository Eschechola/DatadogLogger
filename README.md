## Example to instrumentate .NET application running in K8s on Datadog

<h3> Build your image</h3>
<code>docker build -t logger-api .</code>

<br><br>

<h3>(Optional) Run your image locally</h3>
<code>docker run -d -p 8081:80 logger-api</code>

<br><br>

<h3>(Locally Only) Set Docker default context</h3>
<code>docker context use default</code>

<br><br>

<h3>(Locally Only) Load your image to minikube storage</h3>
<code>minikube image load logger-api</code>

<br><br>

<h3>(Locally Only) List minikube images</h3>
<code>minikube image ls</code>

<br><br>

<h3>Create Datadog secret on K8s</h3>
<code>kubectl create secret generic datadog-secret --from-literal api-key={API_KEY} --from-literal app-key={APP_KEY}</code>

<br><br>

<h3> Create Helm on K8s</h3>
<code>helm install datadog -f datadog-values.yaml --set targetSystem=<TARGET_SYSTEM> datadog/datadog</code>

<br><br>

<h3> (Locally Only) Expose your endpoint</h3>
<code> kubectl expose deployment logger-api --type=NodePort</code>

<br><br>

<h3> (Locally Only) Get your endpoint</h3>
<code> minikube service logger-api --url -n logger</code>
