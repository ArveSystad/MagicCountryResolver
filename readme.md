# MagicCountryResolver

During lunch time, a co-worker proposed this question:

_What are the three countries in the world whose name does not contain any letters in the word "Makrell" (which is the norwegian word for mackerel, as you might have guessed)?_

As hard as that was to figure out in the moment, I solved this for any word with this magnificent piece of software. And the other way around too; what countries contain ALL the letters in a given word.

After building it, you'll find ``mcr.exe`` in ``bin/``.

``mcr all MyWord`` will give you all countries that contain all the unique letters in "MyWord".

``mcr none MyWord``  will give you all countries not containing any of the letters in "MyWord".

This repo contains countries with norwegian names, but these can easily be changed to whatever language you're using - just replace the content in ``countries.txt``.