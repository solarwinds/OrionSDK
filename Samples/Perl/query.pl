#!/usr/bin/perl
use strict;
use warnings;
use REST::Client;
use MIME::Base64;
use URI::Encode qw(uri_encode);
use JSON::Parse ':all';
 
################################################################################
# Configuration
################################################################################
 
my $username = 'domain\username';  # user/pass works too for local SW accounts
my $password = 'password_here';
my $hostname = 'your_hostname';
 
################################################################################
# Execution
################################################################################
 
my $client = REST::Client->new();

# don't verify SSL certs                                                                                                        
$client->getUseragent()->ssl_opts(verify_hostname => 0);                                                                        
$client->getUseragent()->ssl_opts(SSL_verify_mode => 'SSL_VERIFY_NONE');
 
# add authentication header
$client->setHost('https://' . $hostname . ':17778');
$client->addHeader('Authorization', 'Basic ' . encode_base64("$username:$password", ''));
 
# build query string
my $query = sprintf("SELECT Caption, IPAddress FROM Orion.Nodes WHERE Vendor = '%s'", 'Cisco');
my $response = $client->GET('/SolarWinds/InformationService/v3/Json/Query?query=' . uri_encode($query));
 
# examine response
#print 'Response code: ' . $client->responseCode() . "\n";
#print 'JSON response document: ' . $client->responseContent() . "\n";

# parse the JSON response
my $results = parse_json $client->responseContent();

# write the results out
foreach my $node (@{$results->{results}}) {
    print "caption: ", $node->{Caption}, "\n";
    print "address: ", $node->{IPAddress}, "\n";
    print "\n";
}

