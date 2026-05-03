#!/bin/bash
set -e

if [ -z "$JOB_NAME" ] || [ -z "$ENV" ] || [ -z "$VERSION" ]; then
  echo "Missing required variables: JOB_NAME, ENV, VERSION"
  exit 1
fi

if [ "$ENV" = "prod" ] && [ "$APPROVED" != "true" ]; then
  echo "Production deploy requires APPROVED=true"
  exit 1
fi

curl -X POST "$JENKINS_URL/job/$JOB_NAME/buildWithParameters"   --user "$JENKINS_USER:$JENKINS_TOKEN"   -d "env=$ENV"   -d "version=$VERSION"
