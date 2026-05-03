#!/bin/bash
set -e

curl "$JENKINS_URL/job/$JOB_NAME/lastSuccessfulBuild/api/json"   --user "$JENKINS_USER:$JENKINS_TOKEN"
