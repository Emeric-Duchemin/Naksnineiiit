# -*- coding: utf-8 -*-
"""
Created on Thu Dec 10 18:23:32 2020

@author: emech
"""

import numpy as np
import matplotlib.pyplot as plt

filelist = ["angle.txt","speed_b.txt","speed_f.txt","speed_p.txt","target.txt"]
nb_bot = 9
max_episode = 113


content = []
for filename in filelist :
    with open(filename) as f:
        contents = f.readlines()
        # you may also want to remove whitespace characters like `\n` at the end of each line
    content.append([x.strip().replace(",",".") for x in contents])

to_plot = [[[],[],[]] for i in range(len(filelist))]

for i in range(len(filelist)) : 
    cont = content[i]
    for j in range(9,len(cont),9) :
        mean = 0
        to_plot[i][0].append(0)
        to_plot[i][1].append(-1)
        to_plot[i][2].append(-1)
        for k in range(nb_bot) :
            if(j+k>=len(cont)) :
                print(i)
                continue
            mean += float(cont[j+k])
            if(to_plot[i][1][-1] == -1 or to_plot[i][1][-1]>float(cont[j+k])) :
                to_plot[i][1][-1] = float(cont[j+k])
            if(to_plot[i][2][-1] == -1 or to_plot[i][2][-1]<float(cont[j+k])) :
                to_plot[i][2][-1] = float(cont[j+k])
        to_plot[i][0][-1] = mean/nb_bot
    

for i in range(len(filelist)) :
    nb = len(to_plot[i][0])
    x = np.linspace(2,nb,nb)
    plt.figure()
    plt.plot(x,to_plot[i][0],color="red", label="mean")
    plt.scatter(x, to_plot[i][1], color="blue", label = "min")
    plt.scatter(x, to_plot[i][2], color="green", label = "max")
    txt = "Reward for " + filelist[i][:-3] + "for each episode"
    plt.figtext(0.5, 0.01, txt, wrap=True, horizontalalignment='center', fontsize=12)
    plt.legend()
    plt.show()