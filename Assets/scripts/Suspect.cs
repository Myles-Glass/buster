using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * The Suspect class contains all the methods
 * and data that pertains to the suspect that is
 * pulled over.
 */
public class Suspect : MonoBehaviour {

    List<string> traits = new List<string>(new string[] { "Observant", "Distracted", "Talkative", "Shy", "Fearless", "Afraid", "Easily Swayed", "Stubborn", "Weak", "Strong", });

    //The traits
    private string traitOne;
    private string traitTwo;
    private string traitThree;

    //Attributes of the driver
    private int talk;
    private int persuasion;
    private int intimidation;
    private int force;
    private int observe;

    private bool suspectBuilt = false;

    public Text traitOneText;
    public Text traitTwoText;
    public Text traitThreeText;


    void OnRenderObject()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "pullover")
        {
            GameObject Vehicle = GameObject.Find("Vehicle(Clone)");
            if (Vehicle.GetComponent<Vehicle>().getIsSuspect() && !suspectBuilt)
            {
                buildSuspect();
                suspectBuilt = true;
            }

            traitOneText.text = getTraitOne();
            traitTwoText.text = getTraitTwo();
            traitThreeText.text = getTraitThree();
        }
    }
    /*
     * Generates all the attributes and traits for a suspect and applies modifiers
     * 
     */
    public void buildSuspect()
    {
        //Traits
        traitOne = GiveTrait();
        traitTwo = GiveTrait();
        traitThree = GiveTrait();

        //Attributes
        talk = 40 + Random.Range(0, 30);
        persuasion = 20 + Random.Range(0, 30);
        intimidation = 20 + Random.Range(0, 30);
        force = 20 + Random.Range(0, 30);
        observe = 20 + Random.Range(0, 30);

        //Trait modifiers
        traitModifier(traitOne);
        traitModifier(traitTwo);
        traitModifier(traitThree);
    }

    /*
     * Gives a single trait from the list
     * 
     */
    string GiveTrait()
    {
        //Assign trait
        string trait = traits[Random.Range(0, traits.Count)];

        //trait removal from list
        TraitRemoval(trait, "Observant", "Distracted");
        TraitRemoval(trait, "Talkative", "Shy");
        TraitRemoval(trait, "Fearless", "Afraid");
        TraitRemoval(trait, "Easily Swayed", "Stubborn");
        TraitRemoval(trait, "Weak", "Strong");

        return trait;
    }

    /*
     * Compares traits and removes certain ones from list
     * 
     */
    void TraitRemoval(string trait, string traitOneRemove, string traitTwoRemove)
    {
        if (trait == traitOneRemove || trait == traitTwoRemove)
        {
            traits.Remove(traitOneRemove);
            traits.Remove(traitTwoRemove);
        }
    }

    /*
     * Adds modifiers to attributes based on trait
     * 
     */
    void traitModifier(string trait)
    {
        if (trait == "Distracted")
        {
            observe = observe - 20;
        }

        if (trait == "Observant")
        {
            observe = observe + 20;
        }

        if (trait == "Talkative")
        {
            talk = talk - 20;
        }

        if (trait == "Shy")
        {
            talk = talk + 20;
        }

        if (trait == "Afraid")
        {
            intimidation = intimidation - 20;
        }

        if (trait == "Fearless")
        {
            intimidation = intimidation + 20;
        }
        if (trait == "Easily Swayed")
        {
            persuasion = persuasion - 20;
        }

        if (trait == "Stubborn")
        {
            persuasion = persuasion + 20;
        }
        if (trait == "Weak")
        {
            force = force - 20;
        }

        if (trait == "Strong")
        {
            force = force + 20;
        }
    }

    /*
     * Increases or decreases all attributes
     * 
     */
    public void adjustAllAttributes(int adjustment)
    {
        talk = talk + adjustment;
        persuasion = persuasion + adjustment;
        intimidation = intimidation + adjustment;
        force = force + adjustment;
        observe = observe + adjustment;
    }

    //Getter for trait one
    public string getTraitOne()
    {
        return traitOne;
    }

    //Getter for trait two
    public string getTraitTwo()
    {
        return traitTwo;
    }

    //Getter for trait three
    public string getTraitThree()
    {
        return traitThree;
    }

    //Getter for talk attribute
    public int getTalk()
    {
        return talk;
    }

    //Getter for persuasion attribute
    public int getPersuasion()
    {
        return persuasion;
    }

    //Getter for intimidation attribute
    public int getIntimidation()
    {
        return intimidation;
    }

    //Getter for force attribute
    public int getForce()
    {
        return force;
    }

    //Getter for observe attribute
    public int getObserve()
    {
        return observe;
    }

    //Setter for talk attribute
    public void setTalk(int newTalk)
    {
        talk = newTalk;
    }

    //Setter for Persuasion attribute
    public void setPersuasion(int newPersuasion)
    {
        persuasion = newPersuasion;
    }

    //Setter for Intimidation attribute
    public void setIntimidation(int newIntimidation)
    {
        intimidation = newIntimidation;
    }

    //Setter for Force attribute
    public void setForce(int newForce)
    {
        force = newForce;
    }

    //Setter for Observe attribute
    public void setObserve(int newObserve)
    {
        observe = newObserve;
    }
}
