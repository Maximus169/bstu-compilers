from django.urls import path

from . import views

urlpatterns = [
    path('', views.email_send, name='email_send')
]
