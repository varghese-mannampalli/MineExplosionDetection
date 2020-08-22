from django import forms

class FireForm(forms.Form):
    o2 = forms.FloatField(label=' O2%')
    co = forms.FloatField(label=' CO%')
    ch4 = forms.FloatField(label=' CH4%')
    co2 = forms.FloatField(label=' CO2%')
    h2 = forms.FloatField(label=' H2%')
    n2 = forms.FloatField(label=' N2%')
    c2h4 = forms.FloatField(label=' C2H4%')

class EraseForm(forms.Form):
    pass

class DisplayForm(forms.Form):
    pass

class AnalysisForm(forms.Form):
    pass

class TrendForm(forms.Form):
    pass

class PredictForm(forms.Form):
    startdate = forms.DateField(label=' StartDate')
    enddate = forms.DateField(label=' EndDate')

class SerialInputForm(forms.Form):
    pass

class EditForm(forms.Form):
    pass
