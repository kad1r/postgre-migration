# PostgreSQL datatype migrations with EFCore

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

In this example you can see how you migrate your context to PostgreSQL. 
Especially people got some errors with datatype datetime. It should be timestamp on PostgreSQL. So you just need to identify the column type on model creating phase.