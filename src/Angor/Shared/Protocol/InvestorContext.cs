﻿using System;
using System.Collections.Generic;

/// <summary>
/// Contains all the requisite information for an investor to formulate an investment transaction.
/// This data is unique and tailored to each individual investor.
/// </summary>
public class InvestorContext
{
    public string InvestorKey { get; set; }

    public string TokenHashlockKey { get; set; }

  

    public ProjectInvestmentInfo ProjectInvestmentInfo { get; set; }

    public string TransactionHex { get; set; }


    // todo: does this info need to be in this class?
    // ==============================================

    public string ChangeAddress { get; set; }

    public List<string> Utxos { get; set; }
}

