function send_backups()
{
    echo "Se enviarán los respaldos a 192.168.1.101 en 3..."
    sleep 1
    echo "2..."
    sleep 1
    echo "1..."
    sleep 1
    rsync -av /var/respaldos rsync://192.168.1.101/var/respaldos_servidor
}
