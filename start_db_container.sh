#!/bin/bash

while getopts ":i:" opt; do
	case $opt in
		i)
			imageName=$OPTARG
			echo "imageName = $imageName"
			echo "Tearing down any existing containers with deployer=akkadotnet"
			runningContainers=$(docker ps -aq -f label=deployer=akkadotnet)
			if [ ${#runningContainers[@]} -gt 0 ]
				then
					for i in $runningContainers
						do
							if [ "$i" != "" ] # 1st query can return non-empty array with null element
								then
								docker stop $i
								docker rm $i
							fi
						done
			fi
			echo "Starting docker container with imageName=$imageName and name=akka-cassandra-db"
			container_id=$(docker run -d --name=akka-cassandra-db -l deployer=akkadotnet $imageName)
			container_ip=$(docker inspect --format='{{ range .NetworkSettings.Networks }}{{ .IPAddress }}{{ end }}' $container_id)
			# sets environment variables just in case they're needed later in the build pipeline
			export CONTAINER_ID=$container_id
			export CONTAINER_IP=$container_ip
			;;
		:)
			echo "imageName (-i) argument required" >&2
			exit 1
			;;
		\?)
			echo "imageName (-i) flag is required" >&2
			exit 1
			;;
	esac
done