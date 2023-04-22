kubectl config use-context local
kubectl delete -f spaapp-deploy.yaml || true
kubectl create -f spaapp-deploy.yaml --validate=false
kubectl apply -f spaapp-service.yaml --validate=false