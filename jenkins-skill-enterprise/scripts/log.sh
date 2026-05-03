#!/bin/bash
set -e

curl "$JENKINS_URL/job/$JOB_NAME/$BUILD_NUMBER/consoleText"   --user "$JENKINS_USER:$JENKINS_TOKEN"
