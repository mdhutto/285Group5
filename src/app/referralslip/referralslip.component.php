<?php

define('DB_NAME', 'trprt_test');
define('DB_USER', 'root');
define('DB_PASSWORD','phoenix');
define('DB_HOST', 'localhost:3306');

$link = mysql_connect(DB_HOST, DB_USER, DB_PASSWORD);

if(!$link){
  die('Could not connect: ' . mysql_error());
}

$db_selected = mysql_select_db(DB_Name, $link);

if(!db_selected){
  die('Cannot use' . DB_Name . ':' . mysql_error());
}

$formdate = $_POST['formdate'];
$sender_id = $_POST['sender_id'];
$recipient_id = $_POST['recipient_id'];
$client = $_POST['client'];
$client_address = $_POST['client_address'];
$client_phone = $_POST['client_phone'];
$client_city = $_POST['client_city'];
$client_state = $_POST['client_state'];
$client_zip = $_POST['client_zip'];
$client_email = $_POST['client_email'];

$sql = "INSERT INTO referralslipphpmyadmin (formdate, sender_id, recipient_id, client, client_address, client_phone, client_city, client_state, client_zip, client_email) VALUES ('$formdate', '$sender_id', '$recipient_id', '$client', '$client_address', '$client_phone', '$client_city', '$client_state', '$client_zip', '$client_email')";

if(!mysql_query($sql)){
  die('Error: ' . mysql_error());
}

mysql_close();

?>
