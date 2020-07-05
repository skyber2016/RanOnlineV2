# Step to deploy code INT for staging server:
# 1. Run script to backup current source code.
# 2. Run script copy file to server
# 3. Run script install node_modules
# 4. Run script start server

# Export static variable
export ec2_host=18.191.162.236
export ec2_ppk=./ran_online.ppk
export rootDirectory=source
# Echo start deployment
echo 'Start deployment for '$env' server - '$ec2_host
mkdir Deploy
# remove folder ignore
echo 'remove folder ignore'
rm -rf ./BE/node_modules
rm -rf ./BE/assets/*
# Clean folder deploy
echo 'Clean folder deploy'
rm -rf ./Deploy/*
# copy back end
echo 'copy back end'
cp -r ./BE/* ./Deploy/
# build front end
echo 'build front end'
#cd FE && npm i && npm run build && cd ..
# copy production front end
echo 'copy production front end'
cp -r ./FE/dist/FE/* ./Deploy/assets/
# set permission writeable
echo 'set permission writeable'
plink -i $ec2_ppk $ec2_host "mkdir ./source_new && sudo chmod 777 ./source_new"
# Copy source code to server
echo 'Copy source code to server'
pscp -i $ec2_ppk -r ./Deploy/* $ec2_host:/home/ubuntu/source_new
# Backup source current
echo 'Backup source current'
plink -i $ec2_ppk $ec2_host "sudo rm -rf ./backup_source"
plink -i $ec2_ppk $ec2_host "sudo mv ./source ./backup_source"
# rename source folder
echo 'rename source folder'
plink -i $ec2_ppk $ec2_host "sudo mv ./source_new ./source"
# Start server
echo 'Start server'
plink -i $ec2_ppk $ec2_host "cd source && sudo npm i && pm2 start ecosystem.config.js --env production && pm2 save"
echo 'End deployment for '$env' server - '$ec2_host
echo 'Press [Enter] key to continue...'
read