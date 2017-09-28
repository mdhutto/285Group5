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

$form_id = $_POST['form_id'];
$location = $_POST['location'];
$met_id_1 = $_POST['met_id_1'];
$met_id_2 = $_POST['met_id_2'];
$met_id_3 = $_POST['met_id_3'];
$met_id_4 = $_POST['met_id_4'];

$sql = "INSERT INTO referralslipphpmyadmin (form_id, location, met_id_1, met_id_2, met_id_3, met_id_4) VALUES ('$form_id', '$location', '$met_id_1', '$met_id_2', '$met_id_3', '$met_id_4')";

if(!mysql_query($sql)){
  die('Error: ' . mysql_error());
}

mysql_close();

?>
