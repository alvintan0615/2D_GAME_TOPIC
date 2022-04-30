using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public static bool canControl = true;

    //=====Status=====
    public static bool isCanMoveInput = true;
    public static bool isAttacking = false;
    public static bool isAttackingTransition = false;
    public static bool isSkilling = false;
    public static bool isJumping = false;
    public static bool isChanging = false;
    public static bool isClimbing = false;
    public static bool isHurting = false;
    public static bool isDashing = false;
    public static bool isDragging = false;
    public static bool isDialouging = false;
    public static bool isHealing = false;
    public static bool isDead = false;
    //=====CanDoWhat=====
    public static bool canMove = true;
    public static bool canRunAnimation = true;
    public static bool canFlip = true;
    public static bool canJump = true;
    public static bool canAttack = true;
    public static bool canSkill = true;
    public static bool canChange = true;
    public static bool canBeHurt = true;
    public static bool canDash = true;
    public static bool canDrag = true;
    public static bool canStickWall = true;
    public static bool canHealing = true;
    private void Update()
    {
        canMove = canJump = true;
        canRunAnimation = true;
        canFlip = true;
        canSkill = true;
        canChange = true;
        canBeHurt = true;
        canAttack = true;
        canDash = true;
        canDrag = true;
        canStickWall = true;
        canHealing = true;
        if (!isCanMoveInput)
        {
            canMove = false;
        }

        if (isDead)
        {
            canRunAnimation = false;
            canMove = false;
            canJump = false;
            canFlip = false;
            canSkill = false;
            canChange = false;
            canBeHurt = false;
            canAttack = false;
            canDash = false;
            canDrag = false;
            canStickWall = false;
            canHealing = false;
        }

        if (isJumping)
        {
            canRunAnimation = false;
            canMove = canJump = true;
            canFlip = true;
            canSkill = true;
            canChange = false;
            canBeHurt = true;
            canAttack = true;
            canDash = true;
            canDrag = false;
            canStickWall = true;
            canHealing = false;
        }
        
        if (isAttacking)
        {
            canRunAnimation = false;
            canMove = false;
            canJump = true;
            canFlip = false;
            canSkill = false;
            canChange = false;
            canBeHurt = true;
            canAttack = true;
            canDash = false;
            canDrag = false;
            canStickWall = false;
            canHealing = false;
        }

        if (isAttackingTransition)
        {
            canRunAnimation = false;
            canMove = false;
            canJump = true;
            canFlip = true;
            canSkill = false;
            canChange = false;
            canBeHurt = true;
            canAttack = true;
            canDash = false;
            canDrag = false;
            canStickWall = false;
            canHealing = true;
        }
        
        if (isSkilling)
        {
            canRunAnimation = false;
            canMove = canJump = false;
            canFlip = false;
            canSkill = true;
            canChange = false;
            canBeHurt = true;
            canAttack = false;
            canDash = false;
            canDrag = false;
            canStickWall = false;
            canHealing = false;
        }
        if (isChanging)
        {
            canRunAnimation = false;
            canMove = canJump = false;
            canFlip = false;
            canSkill = false;
            canChange = false;
            canBeHurt = false;
            canAttack = false;
            canDash = false;
            canDrag = false;
            canStickWall = false;
            canHealing = false;
        }
        if (isHurting == true)
        {
            canRunAnimation = false;
            canMove = false;
            canJump = false;
            canFlip = true;
            canSkill = false;
            canChange = false;
            canBeHurt = false;
            canAttack = false;
            canDash = false;
            canDrag = false;
            canStickWall = true;
            canHealing = false;
        }
        if (isClimbing)
        {
            isDashing = false;
            canRunAnimation = false;
            canJump = true;
            canFlip = false;
            canSkill = false;
            canChange = false;
            canBeHurt = true;
            canAttack = false;
            canDash = false;
            canDrag = false;
            canStickWall = false;
            canHealing = false;
        }
        
        if (isDashing)
        {
            canRunAnimation = false;
            canJump = true;
            canFlip = false;
            canSkill = false;
            canChange = false;
            canBeHurt = false;
            canAttack = false;
            canDash = true;
            canDrag = false;
            canStickWall = true;
            canHealing = false;
        }
        
        if (isDragging)
        {
            canRunAnimation = false;
            canJump = false;
            canFlip = false;
            canSkill = false;
            canChange = false;
            canBeHurt = true;
            canAttack = false;
            canDash = false;
            canDrag = true;
            canStickWall = false;
            canHealing = false;
        }
        if (isDialouging == true)
        {
            canRunAnimation = false;
            canMove = false;
            canJump = false;
            canFlip = false;
            canSkill = false;
            canChange = false;
            canBeHurt = false;
            canAttack = false;
            canDash = false;
            canDrag = false;
            canStickWall = false;
            canHealing = false;
        }

        if(isHealing == true)
        {
            canRunAnimation = false;
            canMove = false;
            canJump = false;
            canFlip = false;
            canSkill = false;
            canChange = false;
            canBeHurt = false;
            canAttack = false;
            canDash = false;
            canDrag = false;
            canStickWall = false;
            canHealing = false;
        }

        //Debug.Log("isClimbing" + isClimbing);
        //Debug.Log("isHurting" + isHurting);
        /*Debug.Log("isChanging" + isChanging);*/
    }
}
