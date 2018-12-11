/******************************************************************************
 * Copyright (C) Leap Motion, Inc. 2011-2018.                                 *
 * Leap Motion proprietary and confidential.                                  *
 *                                                                            *
 * Use subject to the terms of the Leap Motion SDK Agreement available at     *
 * https://developer.leapmotion.com/sdk_agreement, or another agreement       *
 * between Leap Motion and you, your company or other organization.           *
 ******************************************************************************/

using UnityEngine;
using System.Collections;
using System;
using Leap;

namespace Leap.Unity{
  public class HandEnableDisable : HandTransitionBehavior {
    protected override void Awake() {
      base.Awake();
      gameObject.SetActive(false);
    }

  	protected override void HandReset() {
      gameObject.SetActive(true);
            if(this.gameObject.name == "RigidRoundHand_L")
            {
                Rock_Or_Paper_L.count = 0;
            }

            if(this.gameObject.name == "RigidRoundHand_R")
            {
                Rock_Or_Paper_R.count = 0;
            }
    }

    protected override void HandFinish() {
      gameObject.SetActive(false);
    }

  }
}
