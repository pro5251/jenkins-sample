#!/bin/bash
set -e

curl "$JENKINS_URL/job/$JOB_NAME/$BUILD_NUMBER/api/json"   --user "$JENKINS_USER:$JENKINS_TOKEN"
