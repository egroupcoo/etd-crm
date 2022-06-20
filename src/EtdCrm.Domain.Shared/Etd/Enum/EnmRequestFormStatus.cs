using System;
using System.ComponentModel;

namespace EtdCrm.Etd.Enum
{
	public enum EnmRequestFormStatus
	{
		[Description("Yeni Başvuru")]
		NewRequest= 1,
		[Description("Bilgi İstendi")]
		InfoRequest = 2,
		[Description("Cevaplandı")]
		Answered = 3
	}
}

