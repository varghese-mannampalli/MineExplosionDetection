from django.db import models

class Gasdb(models.Model):
    o2 = models.FloatField()
    co = models.FloatField()
    ch4 = models.FloatField()
    co2 = models.FloatField()
    h2 = models.FloatField()
    n2 = models.FloatField()
    c2h4 = models.FloatField()
    date = models.DateField()

##    def __str__(self):
##        return self.title
