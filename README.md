# Composition

A research project, aiming to uncover if it is possible to automate Android application development, specifically the process of turning an image screen design into code.

## Please Note

This repo is publish only, and serves only to allow others to view its code. Pull requests or issue tickets may be ignored.

Also please note, this project was completed as part of the research component of my Honours Degree. Given a little more time I would have liked to organise my code in a much nicer way. This project was intended to be a 'proof of concept', and with time being a very limited resource code quality was sacrificed a little.

## So what is this? (The short version)

As part of my Honours Degree I needed to research an area, my chosen area was the automation of Android app development. I specifically looked at automating the process of turning image designs of Android screens into a skeleton Android Studio project to enable developers to be more efficient and effective with their time and effort.

I decided to subdivide the problem into functional goals, all of the goals being needed to achieve full automation. I was only able to work on a select few of these goals, achieving partial automation.

So what can it do? Well given an input design, and with the help of the user (whose responsibility is to recognise and select elements from the design) I can classify UI elements on screen, pull some of their styling information (colour primarily), and I can scrape text and images too. It can format a skeleton Android Studio project, with the colour and strings XML files, as well as the images that were scraped. It generates a manifest and Gradle build file too, so effectively all you need to do is copy past the project into an existing blank project, and after a Gradle sync you can run the app on your phone or emulator, and it resembles the input design.

What cant it do? It does not do layouts, it places everything in a linear layout. It does not support every element type, only supports buttons, text entry fields, labels (text views), images and maps.

Why is it limited to only a select few UI elements? To the best of my knowledge, there is no documentation or record of features which I can extract and make classification on (that is classify the widget type based on the features extracted). So I spent a lot of time finding features on which I can make classifications on.

Do you use some form of machine learning? My skills in this department are somewhat lacking, so I developed it using a heuristic algorithm (pretty much I extract the features and make classifications based on them). Although this is what should definitely be used in the future.

## What did you find out? (The short version)

Well first off, I performed two tests to evaluate the effectiveness of the tool: usability testing and false-positive testing.

The usability study consisted of a number of developers (not just Android developers) as well as others who were not from the software field.

Usability testing found some issues that need to be fixed in the interface, however it also found that most people were able to complete the test in under 10 minutes on their first try, and when completing a second test with different input data, more than half of the candidates were able to improve their times by 25% to 50%. Meaning that to a point, with further practice, the amount of time it takes to perform this task can decrease. Compared approximately 35minutes, which is the time it took an experienced developer who performed the same task but without the tool, and was asked to complete it to the same quality of the tools output, it is an improvement.

Also usability study candidates in the feedback survey indicated that they believed that using the tool was much faster than performing the task by hand. Additionally around 92% would have wanted to use the tool either in its current form if released, or a more refined version - indicating that such a tool would be not only accepted by the development community, but potentially embraced.

False-positive testing is effectively comparing the results of the classification algorithm to the results of classifications made by a human.

It was found that button classification success rates were at 27.39%, images at 56.58%, text entry fields at 61.4%, maps at 76.67%, and labels (text views) at 76.05%. The test data used was gathered from the top 300 apps from the Australia's Google Play Store in March 2015, and some were gathered from the website named pttrns.com. All the test data used is available within the bin directory of the "CompositionTests" project.

So what we learned was such automation tools may be embraced by the community, but the classification algorithm used needs more work, potentially replace it with a supervised learning algorithm as well as re-examining the features used for classification.

## What about the long version?

If my thesis is published electronically, after it has undergone review, I will make it available here.

## License

Copyright © 2015 Stanislaw Kowalczyk, BSD-3 Clause License.

This project makes use of dependencies, which are licensed individually as follows below:

This project makes use of EMGU under its open source license: GPL-v3 which can be found here: http://www.gnu.org/licenses/gpl-3.0.txt (sourced from http://www.emgu.com/wiki/index.php/Licensing:#Open_Source_License on 2015-11-23).

This project makes use of Open CV which is under the BSD License which can be found here: http://opencv.org/license.html

This project makes use of Tesseract OCR which is under the Apache 2.0 License, which can be found here: https://github.com/tesseract-ocr/tesseract

This project has an EMGU distribution in it (for ease of compilation) and comes with ZedGraph which is under the LGPL License which can be found here: http://www.gnu.org/licenses/old-licenses/lgpl-2.1.en.html

## How to compile and run

This project was developed using Microsoft's Visual Studio. When opened in Visual Studio, just hit 'Run'.

An EMGU distribution is provided in the EMGU folder (as well as a distribution of OpenCV, Tesseract OCR, and ZedGraph). Upon hitting run in Visual Studio the dependencies are copied over to the bin directory as part of a post-build script.

If you wish to run the false positive tests, feel free to run the 'CompositionTest' project. The test data used for false positive testing can be found in the bin directory of the 'CompositionTest' project.
