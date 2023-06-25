PROJECT=partner
NOW=$(shell date +'%Y%m%d_%H%M')
SHELL=/bin/zsh
.SHELLFLAGS = -e -o pipefail -c


################################################################
# https://askubuntu.com/questions/1410401/arguments-for-make
COMMAND := $(firstword $(MAKECMDGOALS))
ARGS := $(wordlist 2,$(words $(MAKECMDGOALS)),$(MAKECMDGOALS))

%::
	@true

################################################################



POSTGRES_DB_USER=$(POSTGRES_USER)
POSTGRES_DB_PASSWORD=$(POSTGRES_PASSWORD)
POSTGRES_DB_NAME=$(DB_NAME)
POSTGRES_FILE_NAME=$(NOW)_$(DB_NAME).dump
POSTGRES_FILE_NAME_RESTORE=$(DUMP_FILE_NAME)
KC_REALM_FILE_NAME_RESTORE=$(KC_FILE_NAME)

KC_REALM_FILE_NAME=$(NOW)_realm.json


up: infra-up

down: infra-down

logs: infra-logs

restart: infra-restart

infra-up:
	docker-compose -f ./docker-compose.yaml -p $(PROJECT) up -d

infra-build:
	docker-compose -f ./docker-compose.yaml -p $(PROJECT) build

infra-down:
	docker-compose -f ./docker-compose.yaml -p $(PROJECT) down --remove-orphans

infra-logs:
	docker-compose -f ./docker-compose.yaml -p $(PROJECT) logs -t -f

infra-restart:
	docker-compose -f ./docker-compose.yaml -p $(PROJECT) restart ${ARGS}

now:
	echo ${NOW}

set-ip:
	echo -e ""export IP_ADDRESS_LOCAL=eval hostname -I | grep -oE '\b([0-9]{1,3}\.){3}[0-9]{1,3}\b' | head -1"" >> ip.txt


###################################### POSTGRES #######################################
pg-backup:
	docker exec -it ${PROJECT}-postgres-1 /bin/bash -c "pg_dump -U $(POSTGRES_DB_USER) -d $(POSTGRES_DB_NAME) > /tmp/$(POSTGRES_FILE_NAME)"
	mkdir -p ./backups/postgres
	docker cp ${PROJECT}-postgres-1:/tmp/$(POSTGRES_FILE_NAME) ./backups/postgres
	@printf "%s\n" "============================================="
	@printf "%s\n" "Nome do banco inserido: $(POSTGRES_DB_NAME)"
	@printf "%s\n" "Nome do arquivo: $(POSTGRES_FILE_NAME)"
	@printf "%s\n" "Status Postgres: Dump gerado com sucesso!"
	@printf "%s\n" "============================================="

pg-restore:
	docker container stop ${PROJECT}-hasura-1
	docker container stop ${PROJECT}-cms-1
	docker cp ./backups/postgres/$(POSTGRES_FILE_NAME_RESTORE) ${PROJECT}-postgres-1:/tmp
	docker exec -it ${PROJECT}-postgres-1  psql -U $(POSTGRES_DB_USER) -c "DROP DATABASE IF EXISTS $(POSTGRES_DB_NAME);"
	docker exec -it ${PROJECT}-postgres-1  psql -U $(POSTGRES_DB_USER) -c "CREATE DATABASE $(POSTGRES_DB_NAME);"
	docker exec -it ${PROJECT}-postgres-1 /bin/bash -c "psql -U $(POSTGRES_DB_USER) -d $(POSTGRES_DB_NAME) < /tmp/$(POSTGRES_FILE_NAME_RESTORE)"
	docker container start ${PROJECT}-hasura-1
	docker container start ${PROJECT}-cms-1
	@printf "%s\n" "============================================="
	@printf "%s\n" "Nome do banco inserido: $(POSTGRES_DB_NAME)"
	@printf "%s\n" "Nome do arquivo: $(POSTGRES_FILE_NAME_RESTORE)"
	@printf "%s\n" "Status: Restauração do banco gerada com sucesso!"
	@printf "%s\n" "============================================="


###################################### MINIO #######################################

mc-backup:
	mc cp -r  teranft/client-cms-uploads/ ./backups/minio

mc-restore:
	mc cp -r  ./backups/minio/ teranft/client-cms-uploads

mc-clear-temp:
	rm -rf ./backups/minio/*
