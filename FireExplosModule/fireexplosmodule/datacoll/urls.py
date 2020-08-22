from django.urls import path
from django.conf.urls import url
from django.views.generic import ListView, DetailView
from . import views
from .models import Gasdb

urlpatterns = [
    path('',views.index, name = 'index'),
    path('datal/',ListView.as_view(queryset=Gasdb.objects.all().order_by("id")[:1000],template_name="datacoll/result.html")),
    path('analysis/',views.analysis, name ='analysis'),
    path('infopage/',views.infopage, name='infopage'),
    path('trends/', views.trends, name='trend'),
    path('serialinput/', views.serialinput, name='serialinput')
    ]

