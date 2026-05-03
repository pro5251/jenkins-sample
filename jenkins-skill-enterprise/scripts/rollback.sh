#!/bin/bash
set -e

if [ -z "$JOB_NAME" ] || [ -z "$BUILD_NUMBER" ]; then
  echo "Missing JOB_NAME or BUILD_NUMBER"
  exit 1
fi

curl -X POST "$JENKINS_URL/job/$JOB_NAME/$BUILD_NUMBER/rebuild"   --user "$JENKINS_USER:$JENKINS_TOKEN"
