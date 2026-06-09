#!/usr/bin/perl
use strict;
use warnings;
use REST::Client;
use MIME::Base64;
use URI::Encode qw(uri_encode);
use JSON;
use JSON::Parse ':all';
 
################################################################################
# Configuration
################################################################################
 
my $username = 'admin';  # user/pass works too for local SW accounts
my $password = '';
my $hostname = 'tim.swdev.local';
 
################################################################################
# Execution
################################################################################
 
my $client = REST::Client->new();

# don't verify SSL certs                                                                                                        
$client->getUseragent()->ssl_opts(verify_hostname => 0);                                                                        
$client->getUseragent()->ssl_opts(SSL_verify_mode => 'SSL_VERIFY_NONE');
 
# add authentication header
$client->setHost('https://' . $hostname . ':17774');
$client->addHeader('Authorization', 'Basic ' . encode_base64("$username:$password", ''));
 
# build query string
my $query = sprintf("SELECT Caption, IPAddress, Uri FROM Orion.Nodes WHERE Vendor = '%s'", 'Cisco');
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

# Set a custom property on the first node that was returned
my $nodeUri = $results->{results}[0]->{Uri};
my $nodeCustomPropertiesUri = "$nodeUri/CustomProperties";
print $nodeCustomPropertiesUri;
my %customProperties = (Comments => "perl test comment");
$response = $client->POST("/SolarWinds/InformationService/v3/Json/$nodeCustomPropertiesUri", 
	encode_json \%customProperties,
	{'Content-Type' => 'application/json'});
